using Cosmetic_Store.Auth.Model;
using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cosmetic_Store.Pages.Shop
{
    public class ProductModel : PageModel
    {
        // Dependency injection to establish a private connection to a database table by injecting an interface
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly IProduct _product;
        private readonly IShop _shop;

        public ProductModel(IProduct product, IShop shop, UserManager<ApplicationUser> userManager) // A contructor to set propety to the corresponding interface instance
        {
            _userManager = userManager;
            _product = product;
            _shop = shop;
        }

        // A property to be available on the Model property in the Razor Page
        public Product SingleProduct { get; set; }

        [BindProperty]
        public ProductInput Input { get; set; }

        public async Task OnGet(int id) // Asynchronous handler method to process the default GET request
        {
            var cart = new Cart
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            await _shop.CreateCart(cart);
            SingleProduct = await _product.GetProductById(id);
        }

        // Create cart items by pulling data information from Product and Cart tables
        // If the product already exists then call update operation instead of get operation
        public async Task<IActionResult> OnPost(int id)
        {
            // this is used to save the previous URL
            string urlAnterior = Request.Headers["Referer"].ToString();
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return Redirect("/Accounts/Login");

            }
            var cart = await _shop.GetCartByUserId(user.Id);
            if (ModelState.IsValid)
            {
                var cartItem = new CartProduct
                {
                    CartID = cart.CartId,
                    ProductID = id,
                    Quantity = Input.Quantity
                };
                if (await _shop.GetCartProductByProductIdForUser(user.Id, id) != null)
                {
                    CartProduct existingCartItem = await _shop.GetCartProductByProductIdForUser(user.Id, id);
                    existingCartItem.Quantity += Input.Quantity;
                    await _shop.UpdateCartProduct(existingCartItem);
                }
                else
                {
                    await _shop.CreateCartProduct(cartItem);
                }
            }
            return Redirect(urlAnterior);
        }

        public class ProductInput
        {
            public int Quantity { get; set; } = 1;
        }
    }
}
