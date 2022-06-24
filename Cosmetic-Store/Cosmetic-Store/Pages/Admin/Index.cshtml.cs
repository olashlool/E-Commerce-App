using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cosmetic_Store.Pages.Admin
{
    public class IndexModel : PageModel
    {
        [Authorize(Policy = "Administrator")]
        public void OnGet() // Add Authorize tag and add roles so only the admin can access this page
        {
        }
    }
}
