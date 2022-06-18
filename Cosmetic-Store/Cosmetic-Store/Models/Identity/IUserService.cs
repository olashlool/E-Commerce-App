using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Identity
{
    public interface IUserService
    {
        public Task<UserDto> Register(Register register, ModelStateDictionary modelstate);
        public Task<UserDto> Login(string username, string password);
        public Task<UserDto> GetUser(ClaimsPrincipal principal);
        public Task Logout();


    }
}
