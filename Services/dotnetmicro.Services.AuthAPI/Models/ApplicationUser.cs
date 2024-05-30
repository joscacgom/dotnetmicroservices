using Microsoft.AspNetCore.Identity;

namespace dotnetmicro.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}