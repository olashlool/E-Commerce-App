using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmetic_Store.Pages.Orders
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        private readonly IOrder _order;

        public IndexModel(IOrder order) // The constructor to bring in IOrder interface that enables getting information from the order data table
        {
            _order = order;
        }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderItems> OrderItems { get; set; }
        public async Task OnGetAsync() // Get all the orders from the order table AND Get all the order items from the each order
        {
            Orders = await _order.GetOrders();
            OrderItems = await _order.GetOrderItems();
        }
    }
}
