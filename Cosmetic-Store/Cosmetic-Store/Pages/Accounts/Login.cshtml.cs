using Cosmetic_Store.Auth.Model;
using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Cosmetic_Store.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private readonly IUserService userService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginModel(IUserService userSer, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            userService = userSer;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [BindProperty]
        public Login Login { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            Login userlogin = new Login()
            {
                UserName = Login.UserName,
                Password = Login.Password
            };
            var user = await userService.Login(userlogin.UserName, userlogin.Password);
            var user1 = await _userManager.FindByNameAsync(userlogin.UserName);
            var roles = await _userManager.GetRolesAsync(user1);

            if (user != null)
            {
                if (roles.Contains("Administrator"))
                {
                    return RedirectToPage("/Admin/Index");
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }
            }
            else
            {
                return Page();

            }
            
        } 
    } 
}
