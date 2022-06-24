using Cosmetic_Store.Auth.Model;
using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Cosmetic_Store.Pages.Shop
{
    public class ProductModel : PageModel
    {
        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProduct _product;
        private readonly IShop _shop;


        /// <summary>
        /// A contructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="inventory">IInventory interface</param>
        public ProductModel(IProduct product, IShop shop, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _product = product;
            _shop = shop;
        }

        /// <summary>
        /// A property to be available on the Model property in the Razor Page
        /// </summary>
        public Product SingleProduct { get; set; }

        [BindProperty]
        public ProductInput Input { get; set; }

        /// <summary>
        /// Asynchronous handler method to process the default GET request
        /// </summary>
        /// <returns>A product from the database based on the id</returns>
        public async Task OnGet(int id)
        {
            SingleProduct = await _product.GetProductById(id);
        }

        /// <summary>
        /// Create cart items by pulling data information from Product and Cart tables
        /// If the product already exists then call update operation instead of get operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Redirect to /Shop/Cart page</returns>
        public async Task<IActionResult> OnPost(int id)
        {
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
            return Redirect("/Shop/Cart");
        }

        public class ProductInput
        {
            public int Quantity { get; set; } = 1;
        }
    }
}
