using BLL.DTO;

namespace BLL.Services
{
    public interface IIdentityService
    {
        void Create(IdentityUserDTO identityUser);
    }
}