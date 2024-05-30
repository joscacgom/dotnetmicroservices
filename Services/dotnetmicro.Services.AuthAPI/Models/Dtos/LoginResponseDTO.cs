namespace dotnetmicro.Services.AuthAPI.Models.Dtos
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}