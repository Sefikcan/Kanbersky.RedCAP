using DotNetCore.CAP;
using Kanbersky.RedCAP.Common.Shared.ConsumerModel;
using Microsoft.Extensions.Logging;

namespace Kanbersky.RedCAP.Services.Consumers
{
    public class OrderCreatedSendEmailConsumer : ICapSubscribe
    {
        private readonly ILogger<OrderCreatedSendEmailConsumer> _logger;

        public OrderCreatedSendEmailConsumer(ILogger<OrderCreatedSendEmailConsumer> logger)
        {
            _logger = logger;
        }

        [CapSubscribe(nameof(CreateOrderSendEmailModel))]
        public void OrderCreatedSendEmail(CreateOrderSendEmailModel createOrderSendEmail)
        {
            _logger.LogInformation("Send Email Start!");

            //Some Business Operation

            _logger.LogInformation("Send Email End!");
        }
    }
}
