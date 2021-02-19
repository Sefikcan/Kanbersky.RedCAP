using DotNetCore.CAP;
using Microsoft.Extensions.Logging;

namespace Kanbersky.RedCAP.Consumer.Consumers
{
    public class OrderCreatedEmailConsumer : ICapSubscribe
    {
        private readonly ILogger<OrderCreatedEmailConsumer> _logger;

        public OrderCreatedEmailConsumer(ILogger<OrderCreatedEmailConsumer> logger)
        {
            _logger = logger;
        }

        [CapSubscribe("")]
        public void Handle()
        {
            _logger.Log(LogLevel.Debug, "");
        }
    }
}
