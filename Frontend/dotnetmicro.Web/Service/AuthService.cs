using dotnetmicro.Web.Service.IService;
using dotnetmicro.Web.Models;
using dotnetmicro.Web.Utils;

namespace dotnetmicro.Web.Service
{
    public class AuthService: IAuthService{

        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> Login(LoginRequestDTO loginRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthAPIBase + "/api/auth/Login",
                Data = loginRequestDTO
            });
        }

        public async Task<ResponseDTO?> RegisterUser(RegistrationRequestDTO registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthAPIBase + "/api/auth/Register",
                Data = registrationRequestDto
            });        
        }

        public async Task<ResponseDTO> AssignRole(RegistrationRequestDTO registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthAPIBase + "/api/auth/AssignRole",
                Data = registrationRequestDto
            });
        }

    }
}