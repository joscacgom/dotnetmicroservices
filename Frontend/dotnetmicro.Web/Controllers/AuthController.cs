using dotnetmicro.Web.Models;
using dotnetmicro.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dotnetmicro.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO model = new LoginRequestDTO();
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegistrationRequestDTO model = new RegistrationRequestDTO();
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

    }
}