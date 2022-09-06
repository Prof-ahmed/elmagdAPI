using AutoMapper;
using Domain.shopdb;
using elmagdAPI.Dto;
using System;

namespace elmagdAPI.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CusCart, PostCustomerCart>().ReverseMap();
            });

            Mapper = MapperConfiguration.CreateMapper();
        }
        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }

    }
}
