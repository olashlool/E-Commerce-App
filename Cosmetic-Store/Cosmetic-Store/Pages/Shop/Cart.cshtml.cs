using Cosmetic_Store.Auth.Model;
using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmetic_Store.Pages.Shop
{
    public class CartModel : PageModel
    {
        // Dependency injection to establish a private connection to a database table by injecting an interface
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly IShop _shop;
        public CartModel(UserManager<ApplicationUser> userManager, IShop shop) // A contructor to set propety to the corresponding interface instance
        {
            _shop = shop;
            _userManager = userManager;
        }

        public IEnumerable<CartProduct> CartProducts { get; set; } // A property to be available on the Model property in the Razor Page

        public async Task OnGet() //  method to process the default GET request
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            CartProducts = await _shop.GetCartProductByUserId(user.Id);
        }
        [HttpPost]
        public async Task<IActionResult> OnPostUpdate(int id)
        {
            int updatedQuantity = Convert.ToInt32(Request.Form["Quantity"]);
            ApplicationUser user = await _userManager.GetUserAsync(User);
            CartProduct cartItem = await _shop.GetCartProductByProductIdForUser(user.Id, id);

            cartItem.Quantity = updatedQuantity;
            await _shop.UpdateCartProduct(cartItem);

            return RedirectToPage();
        }
        [HttpPost]
        public async Task<IActionResult> OnPostDelete(int id)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            await _shop.RemoveCartProduct(user.Id, id);

            return RedirectToPage();
        }
    }
}
