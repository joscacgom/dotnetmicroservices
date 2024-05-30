using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dotnetmicro.Services.AuthAPI.Service.IService;
using dotnetmicro.Services.AuthAPI.Models.Dtos;

namespace dotnetmicro.Services.AuthAPI.AddControllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDTO _response;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new ResponseDTO();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO registrationRequestDTO)
        {
            var user = await _authService.Register(registrationRequestDTO);
            if(user == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Something went wrong";
                return BadRequest(_response);
            }

            _response.IsSuccess = true;
            _response.Message = "User created successfully";
            _response.Result = user;

            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var loginResponse = await _authService.Login(loginRequestDTO);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Invalid credentials";
                return BadRequest(_response);
            }
            else
            {
                _response.IsSuccess = true;
                _response.Message = "Login successful";
                _response.Result = loginResponse;
                return Ok(_response);
            }
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDTO roleRequestDTO)
        {
           var assignRoleResponse = await _authService.AssignRole(roleRequestDTO.Email, roleRequestDTO.Role.ToUpper());
              if (!assignRoleResponse)
              {
                _response.IsSuccess = false;
                _response.Message = "Role assignment failed";
                return BadRequest(_response);
              }
              else
              {
                _response.IsSuccess = true;
                _response.Message = "Role assigned successfully";
                return Ok(_response);
              }
        }
    }
}