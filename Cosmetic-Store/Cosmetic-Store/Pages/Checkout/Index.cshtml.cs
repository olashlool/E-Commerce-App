using Cosmetic_Store.Auth.Model;
using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Cosmetic_Store.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmail _email;
        private readonly IShop _shop;
        private readonly IOrder _order;

        public IndexModel(UserManager<ApplicationUser> userManager, IEmail emailSender, IShop shop, IOrder order) // Constructor to take UserManager, IEmail, IShop, and IOrder interfaces to enable the checkout process
        {
            _userManager = userManager;
            _email = emailSender;
            _shop = shop;
            _order = order;
        }

        /// <summary>
        /// Bind the Input object that contains all the required information for checkout to the property
        /// </summary>
        [BindProperty]
        public CheckoutInput Input { get; set; }

        public void OnGet()
        {
        }

        /// <summary>
        /// This post operation uses UserManager to get the current signed in user
        /// Set a variable to store the total costs of all items in the cart
        /// Set variables to store email contents for an order summary email that is to be sent out to a user after they check out
        /// After the email is sent out, redirect the user to receipt page
        /// </summary>
        /// <returns>If the ckeckout process is successful, redirect to the receipt page. Otherwise, returns to the same page</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.GetUserAsync(User);

                Order order = new Order
                {
                    UserID = user.Id,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Address = Input.Address,
                    Address2 = Input.Address2,
                    City = Input.City,
                    State = Input.State,
                    Zip = Input.Zip,
                    Timestamp = DateTime.Now.ToString()
                };
                 
                await _order.CreateOrder(order);

                order = await _order.GetLatestOrderForUser(user.Id);

                IEnumerable<CartProduct> cartItems = await _shop.GetCartProductByUserId(user.Id);
                IList<OrderItems> orderItems = new List<OrderItems>();
                double total = 0;

                foreach (var cartItem in cartItems)
                {
                    OrderItems orderItem = new OrderItems
                    {
                        OrderID = order.ID,
                        ProductID = cartItem.ProductID,
                        Quantity = cartItem.Quantity
                    };
                    orderItems.Add(orderItem);
                    total += cartItem.Product.Price * cartItem.Quantity;
                }

                double finalCost = total * 1.1;

                //string subject = "Purhcase Summary From Cosmetic Store!";
                //string message =
                //    $"<p>Hello {user.UserName},</p>" +
                //    $"<p>&nbsp;</p>" +
                //    $"<p>Below is your recent purchase summary</p>" +
                //    $"<p>Total: ${finalCost.ToString("F")}\n</p>" + "<a href=\"https://dotnet-ecommerce-tiny-plants.azurewebsites.net\">Click here to shop more!<a>";

                //await _email.SendEmailAsync(user.Email, subject, message);
                foreach (var item in orderItems)
                {
                    await _order.CreateOrderItem(item);
                }
                await _shop.RemoveCartProducts(cartItems);

                return RedirectToAction("Index","Category");
            }
            return Page();
        }
        public class CheckoutInput
        {
            [Display(Name = "Purchased Date:")]
            public DateTime Date { get; set; }

            [Required]
            [Display(Name = "First Name:")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name:")]
            public string LastName { get; set; }

            [Required]
            public string Address { get; set; }

            [Display(Name = "Address 2:")]
            public string Address2 { get; set; }

            [Required]
            public string City { get; set; }

            [Required]
            public string State { get; set; }

            [Required]
            [DataType(DataType.PostalCode)]
            [Compare("Zip", ErrorMessage = "The is an invalid zip code")]
            public string Zip { get; set; }
        }

    }
}
