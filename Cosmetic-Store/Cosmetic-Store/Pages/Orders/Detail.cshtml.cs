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
    public class DetailModel : PageModel
    {
        // Bring in IOrder interface to enable the implementation
        private readonly IOrder _order;

        public DetailModel(IOrder order)
        {
            _order = order;
        }

        // Get the Order Items from the database and store in OrderItems with a data type of IEnumerable<OrderItems>
        public IEnumerable<OrderItems> OrderItems { get; set; }

        public async Task OnGetAsync(int id) // Get all the order items details by the order id that is selected
        {
            OrderItems = await _order.GetOrderItemsByOrderId(id); 
        }
    }
}
