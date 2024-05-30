namespace dotnetmicro.Web.Models
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}