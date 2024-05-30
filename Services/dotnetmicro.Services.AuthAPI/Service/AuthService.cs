using dotnetmicro.Services.AuthAPI.Data;
using Microsoft.AspNetCore.Identity;
using dotnetmicro.Services.AuthAPI.Models;
using dotnetmicro.Services.AuthAPI.Models.Dtos;
using dotnetmicro.Services.AuthAPI.Service.IService;
using System.Threading.Tasks;

namespace dotnetmicro.Services.AuthAPI.Service
{
    public class AuthService: IAuthService {

        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if(user != null)
            {
                if(!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }

                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }

            return false;

        }

        public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
               UserName = registrationRequestDto.Email,
               Email = registrationRequestDto.Email,
               NormalizedEmail = registrationRequestDto.Email.ToUpper(),
               Name = registrationRequestDto.Name,
               PhoneNumber = registrationRequestDto.PhoneNumber,
            };

            try{
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if(result.Succeeded)
                {
                    var userToReturn = _context.ApplicationUsers.FirstOrDefault(u => u.Email == registrationRequestDto.Email);
                    return new UserDTO()
                    {
                        Name = userToReturn.Name,
                        Email = userToReturn.Email,
                        PhoneNumber = userToReturn.PhoneNumber,
                        ID = userToReturn.Id
                    };
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            
            }
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if(user==null || !isValid)
            {
                return new LoginResponseDTO()
                {
                    User = null,
                    Token = ""
                };
            }

            return new LoginResponseDTO()
            {
                User = new UserDTO()
                {
                    Name = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    ID = user.Id
                },
                Token = _jwtTokenGenerator.GenerateToken(user)
            };
        }

    }
}