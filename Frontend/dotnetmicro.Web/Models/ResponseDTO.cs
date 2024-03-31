namespace dotnetmicro.Web.Models
{
    public class ResponseDTO
    {
        public object? Result { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; } = "";
    }
}