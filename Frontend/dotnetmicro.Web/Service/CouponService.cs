using dotnetmicro.Web.Service.IService;
using dotnetmicro.Web.Models;
using dotnetmicro.Web.Utils;

namespace dotnetmicro.Web.Service
{
    public class CouponService: ICouponService{

        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreateCoupon(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.POST,
                Url = SD.CouponAPIBase + "/api/coupon",
                Data = couponDTO
            });
        }

        public async Task<ResponseDTO?> DeleteCoupon(int couponId)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + "/api/coupon/" + couponId
            });
        }

        public async Task<ResponseDTO?> GetAllCoupons()
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDTO?> GetCouponById(int couponId)
        {
            return await _baseService.SendAsync(new RequestDTO
            {

                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/" + couponId
            });
        }

        public async Task<ResponseDTO?> GetCouponByCode(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCouponCode/" + couponCode
            });
        }

        public async Task<ResponseDTO?> UpdateCoupon(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.CouponAPIBase + "/api/coupon",
                Data = couponDTO
            });
        }

        



    }
}