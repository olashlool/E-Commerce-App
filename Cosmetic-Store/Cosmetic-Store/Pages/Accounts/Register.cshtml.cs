using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Identity;
using Cosmetic_Store.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Cosmetic_Store.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService userService;
        private readonly IEmail _email;


        public RegisterModel(IUserService userSer , IEmail email)
        {
            userService = userSer;
            _email = email;
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

            //string subject = "Welcome to Cosmetic Store!";
            //string message =
            //    $"<p>Hello {newuser.UserName}, </p>" +
            //    $"<p>&nbsp;</p>" +
            //    $"<p>Welcome to Cosmetic Store! You have successfully created a new account.</p>" +
            //    $"<p>At Cosmetic Store, we provides unique and beautiful product for you to choose from!\n</p>" + "<a href=\"https://cosmetic-storeapp.azurewebsites.net/\">Start shoping now!<a>";

            //await _email.SendEmailAsync(newuser.Email, subject, message);

            await userService.Register(newuser, this.ModelState);

            return RedirectToPage("/Accounts/Login");

        }
    }
}
