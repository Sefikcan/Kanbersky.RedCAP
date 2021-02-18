using DotNetCore.CAP;
using Kanbersky.RedCAP.Services.DTO.Request;
using Kanbersky.RedCAP.Services.DTO.Response;
using MediatR;
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

        public CreateOrderCommandHandler(ICapPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task<CreateOrderResponseModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            //TODO: Create Order Business

            //TODO: Send Publish Cap
            await _publisher.PublishAsync("", "");

            //TODO: Mapster
            return null;
        }
    }
}
