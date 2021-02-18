using Kanbersky.RedCAP.Core.Mappings.Abstract;
using Mapster;

namespace Kanbersky.RedCAP.Core.Mappings.Concrete.Mapster
{
    public class MapsterMapping : IMapping
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TDestination>();
        }
    }
}
