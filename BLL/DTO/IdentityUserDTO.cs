using Microsoft.AspNetCore.Identity;

namespace BLL.DTO
{
    public class IdentityUserDTO : IdentityUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}