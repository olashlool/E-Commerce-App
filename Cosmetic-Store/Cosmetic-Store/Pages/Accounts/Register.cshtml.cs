using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Cosmetic_Store.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService userService;

        public RegisterModel(IUserService userSer)
        {
            userService = userSer;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public Register Register { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            Register newuser = new Register
            {
                UserName = Register.UserName,
                Password = Register.Password,
                Email = Register.Email
            };
            await userService.Register(newuser, this.ModelState);
            return RedirectToPage("/Accounts/Login");

        }
    }
}
