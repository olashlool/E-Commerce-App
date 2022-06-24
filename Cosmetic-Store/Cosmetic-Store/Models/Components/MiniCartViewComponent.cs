using Cosmetic_Store.Auth.Model;
using Cosmetic_Store.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Components
{
    public class MiniCartViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IShop _shop;
    
        public MiniCartViewComponent(UserManager<ApplicationUser> userManager, IShop shop)
        {
            _userManager = userManager;
            _shop = shop;
        }
    
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
            var cartItems = await _shop.GetCartProductByUserId(userId);
    
            return View(cartItems);
        }
    }
}
