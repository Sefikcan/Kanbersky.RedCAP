namespace Kanbersky.RedCAP.Core.Mappings.Abstract
{
    public interface IMapping
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
