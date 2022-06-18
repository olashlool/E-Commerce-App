using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cosmetic_Store.Controllers
{
    public class AccountController : Controller
    {

        private IUserService userService;

        public AccountController(IUserService userSer)
        {
            userService = userSer;
        }
        public IActionResult Login()
        {
            return RedirectToPage("/Accounts/Login");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> SignUp(Register register)
        {
            var user = await userService.Register(register, this.ModelState);
            if (ModelState.IsValid)
            {
                return Redirect("Login"); // need path, will append to basic path, hit / that mean redirect to home page
            }
            return View(register);
        }
      
        public async Task<ActionResult<UserDto>> Authenticate(Login login)
        {
            var user = await userService.Login(login.UserName, login.Password);
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index", "Category");
        }
        // cookie will be sent with every request automatically

        // provide strong password

        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return RedirectToAction("Index", "Category");
        }
    }
}
