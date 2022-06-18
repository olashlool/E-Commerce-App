using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Cosmetic_Store.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private readonly IUserService userService;

        public LoginModel(IUserService userSer)
        {
            userService = userSer;
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
            if (user != null)
            {
                return RedirectToAction("Index","Category");

            }
            else
            {
                return Page();

            }
        }
    }
    }
