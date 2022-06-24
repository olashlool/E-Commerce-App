using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Interface
{
    public interface IShop
    {
        public Task<Cart> CreateCart(Cart cart);
        public Task<CartProduct> CreateCartProduct(CartProduct cartProduct);
        public Task<Cart> GetCartByUserId(string userId);
        public Task<IEnumerable<CartProduct>> GetCartProductByUserId(string userId);
        public Task<CartProduct> GetCartProductByProductIdForUser(string userId, int productId);
        public Task<CartProduct> UpdateCartProduct(CartProduct cartProduct);
        public Task RemoveCartProduct(string userId, int productId);
        public Task RemoveCartProducts(IEnumerable<CartProduct> cartProduct);

    }
}
