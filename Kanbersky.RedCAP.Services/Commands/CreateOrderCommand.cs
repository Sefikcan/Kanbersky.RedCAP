using DotNetCore.CAP;
using Kanbersky.RedCAP.Common.Shared.ConsumerModel;
using Kanbersky.RedCAP.Core.Infrastructure.Abstract.EntityFramework;
using Kanbersky.RedCAP.Core.Mappings.Abstract;
using Kanbersky.RedCAP.Core.Settings.Concrete.Outbox;
using Kanbersky.RedCAP.Infrastracture.DataAccess.EntityFramework;
using Kanbersky.RedCAP.Services.DTO.Request;
using Kanbersky.RedCAP.Services.DTO.Response;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Kanbersky.RedCAP.Services.Commands
{
    public class CreateOrderCommand : IRequest<CreateOrderResponseModel>
    {
        public CreateOrderRequestModel CreateOrderRequest { get; set; }

        public CreateOrderCommand(CreateOrderRequestModel createOrderRequest)
        {
            CreateOrderRequest = createOrderRequest;
        }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponseModel>
    {
        private readonly ICapPublisher _publisher;
        private readonly IMapping _mapping;
        private readonly OutboxDbSettings _outboxDbSettings;
        private readonly OrderDbContext _orderContext;
        //private readonly IEfGenericRepository<Infrastracture.Entities.Order> _orderRepository;

        public CreateOrderCommandHandler(ICapPublisher publisher,
            IMapping mapping,
            OrderDbContext orderContext,
            //IEfGenericRepository<Infrastracture.Entities.Order> orderRepository,
            OutboxDbSettings outboxDbSettings)
        {
            _publisher = publisher;
            _mapping = mapping;
            _orderContext = orderContext;
            //_orderRepository = orderRepository;
            _outboxDbSettings = outboxDbSettings;
        }

        public async Task<CreateOrderResponseModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            CreateOrderResponseModel orderResponseModel = null;

            using (var trans = _orderContext.Database.BeginTransaction(_publisher, autoCommit: true))
            {
                var order = _mapping.Map<CreateOrderRequestModel, Infrastracture.Entities.Order>(request.CreateOrderRequest);

                var response = await _orderContext.AddAsync(order);
                await _orderContext.SaveChangesAsync();
                orderResponseModel = _mapping.Map<Infrastracture.Entities.Order, CreateOrderResponseModel>(response.Entity);

                _publisher.Publish(nameof(CreateOrderSendEmailModel), new CreateOrderSendEmailModel { OrderId = response.Entity.Id });
            }

            return orderResponseModel;
        }
    }
}
