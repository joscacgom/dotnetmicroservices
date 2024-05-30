using dotnetmicro.Web.Models;
namespace dotnetmicro.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDTO?> Login(LoginRequestDTO loginRequestDTO);
        Task<ResponseDTO?> RegisterUser(RegistrationRequestDTO registrationRequestDto);
        Task<ResponseDTO> AssignRole(RegistrationRequestDTO registrationRequestDto);
    }
}