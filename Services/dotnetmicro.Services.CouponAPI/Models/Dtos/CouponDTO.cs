namespace dotnetmicro.Services.CouponAPI.Models.Dtos
{
    public class CouponDTO
    {
        public int Id { get; set; }

        public string CouponCode { get; set; } = "";

        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }
    }
}