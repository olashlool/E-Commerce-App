using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cosmetic_Store.Pages.Admin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [Authorize(Roles = "Administrator")]
        [Authorize(Policy = "AdminOnly")]
        public void OnGet() // Add Authorize tag and add roles so only the admin can access this page
        {
        }
    }
}
