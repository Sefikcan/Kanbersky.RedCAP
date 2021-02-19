using Kanbersky.RedCAP.Core.Settings.Abstract;

namespace Kanbersky.RedCAP.Core.Settings.Concrete.Outbox
{
    public class OutboxRabbitMQSettings : ISettings
    {
        public string Uri { get; set; }
    }
}
