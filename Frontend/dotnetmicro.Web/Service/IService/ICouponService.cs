using dotnetmicro.Web.Models;
namespace dotnetmicro.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO?> GetAllCoupons();
        Task<ResponseDTO?> GetCouponById(int couponId);
        Task<ResponseDTO?> GetCouponByCode(string couponCode);
        Task<ResponseDTO?> CreateCoupon(CouponDTO couponDTO);
        Task<ResponseDTO?> UpdateCoupon(CouponDTO couponDTO);
        Task<ResponseDTO?> DeleteCoupon(int couponId);
    }
}