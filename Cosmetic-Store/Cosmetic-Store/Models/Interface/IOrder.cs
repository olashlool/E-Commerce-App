using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Interface
{
    public interface IOrder
    {
        public Task<Order> CreateOrder(Order order);
        public Task<OrderItems> CreateOrderItem(OrderItems orderItem);
        public Task<Order> GetLatestOrderForUser(string userId);
        public Task<IEnumerable<Order>> GetOrdersByUserId(string userId);
        public Task<IEnumerable<Order>> GetOrders();
        public Task<IList<OrderItems>> GetOrderItemsByOrderId(int orderId);
        public Task<IEnumerable<OrderItems>> GetOrderItems();
        public Task<OrderItems> UpdateOrderItems(OrderItems orderItems);

    }
}
