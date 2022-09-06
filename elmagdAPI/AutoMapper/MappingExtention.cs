using System.Collections.Generic;

namespace elmagdAPI.AutoMapper
{
    public static class MappingExtention
    {

        internal static TEntity ToEntity<TDto, TEntity>(this TDto dto) where TEntity : class
        {
            return AutoMapperConfiguration.Mapper.Map<TEntity>(dto);
        }
        
        internal static TDto ToDto<TEntity, TDto>(this TEntity entity) where TDto : class
        {
            return AutoMapperConfiguration.Mapper.Map<TDto>(entity);
        }
        internal static IList<TDto> ToDtoIList<TEntity, TDto>(this IEnumerable<TEntity> entity)
            where TDto : class
        {
            return AutoMapperConfiguration.Mapper.Map<IList<TDto>>(entity);
        }

        internal static List<TDto> ToDtoList<TEntity, TDto>(this IEnumerable<TEntity> entity)
         where TDto : class
        {
            return AutoMapperConfiguration.Mapper.Map<List<TDto>>(entity);
        }
        
    }
}
