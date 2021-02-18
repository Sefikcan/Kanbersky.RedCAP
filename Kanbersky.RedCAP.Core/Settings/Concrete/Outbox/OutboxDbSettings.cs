using Kanbersky.RedCAP.Core.Settings.Abstract;

namespace Kanbersky.RedCAP.Core.Settings.Concrete.Outbox
{
    public class OutboxDbSettings : ISettings
    {
        public string ConnectionStrings { get; set; }
    }
}
