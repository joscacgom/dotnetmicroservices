using AutoMapper;
using dotnetmicro.Services.CouponAPI.Models;
using dotnetmicro.Services.CouponAPI.Models.Dtos;

namespace dotnetmicro.Services.CouponAPI
{
    public class MappingConfig : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Coupon, CouponDTO>();
                cfg.CreateMap<CouponDTO, Coupon>();
            });
        }
    }
}