using AutoMapper;
using Kanbersky.RedCAP.Core.Mappings.Abstract;

namespace Kanbersky.RedCAP.Core.Mappings.Concrete.AutoMapper
{
    public class AutoMapping : IMapping
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<TSource, TDestination>());

            var mapper = new Mapper(config);
            var result = mapper.Map<TSource, TDestination>(source);


            return result;
        }
    }
}
