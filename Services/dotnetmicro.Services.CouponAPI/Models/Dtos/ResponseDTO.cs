namespace dotnetmicro.Services.CouponAPI.Models.Dtos
{
    public class ResponseDTO
    {
       public object? Result { get; set; }
       public bool IsSuccess { get; set; }
       public string Message { get; set; } = "";
    }
}