using dotnetmicro.Services.AuthAPI.Models;

namespace dotnetmicro.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
       string GenerateToken(ApplicationUser applicationUser);
    }
}