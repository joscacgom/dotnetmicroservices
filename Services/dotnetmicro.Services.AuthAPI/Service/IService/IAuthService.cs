using dotnetmicro.Services.AuthAPI.Models.Dtos;

namespace dotnetmicro.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}