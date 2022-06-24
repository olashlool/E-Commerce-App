using Cosmetic_Store.Data;
using Cosmetic_Store.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Services
{
    public class ShopServices : IShop
    {
        /// <summary>
        /// Establishes a private connection to a database via dependency injection
        /// </summary>
        private readonly CosmeticDBContext _context;

        public ShopServices(CosmeticDBContext context)
        {
            _context = context;
        }

        public async Task<Cart> CreateCart(Cart cart) // Saves a cart data by saving an Cart object into the connected database
        {
            _context.Entry(cart).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task<CartProduct> CreateCartProduct(CartProduct cartProduct) // Saves a cartProduct data by saving an CartProduct object into the connected database
        {
            _context.Entry(cartProduct).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return cartProduct;
        }

        public async Task<Cart> GetCartByUserId(string userId) // Gets a cart data based on the userId from the connected database
        {
            return await _context.Carts.FirstOrDefaultAsync(cart => cart.UserId == userId);
        }

        public async Task<CartProduct> GetCartProductByProductIdForUser(string userId, int productId) // Gets a cartProduct data based on the userId and productId from the connected database
        {
            var cartProduct = await GetCartProductByUserId(userId);
            return cartProduct.FirstOrDefault(cart => cart.ProductID == productId);
        }

        public async Task<IEnumerable<CartProduct>> GetCartProductByUserId(string userId) // Gets all of the cartProduct data based on the userId from the connected database
        {
            Cart cart = await GetCartByUserId(userId);
            return _context.CartProducts.Where(cartItem => cartItem.CartID == cart.CartId).Include(x => x.Product);
        }

        public async Task RemoveCartProduct(string userId, int productId) // Deletes a cartProduct data based on the userId and productId from the connected database
        {
            CartProduct cartItem = await GetCartProductByProductIdForUser(userId, productId);
            _context.CartProducts.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCartProducts(IEnumerable<CartProduct> cartProduct) // Deletes a cartProduct of cartItems data from the connected database
        {
            _context.CartProducts.RemoveRange(cartProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<CartProduct> UpdateCartProduct(CartProduct cartProduct) // Update an cartProduct data from the connected database
        {
            var updateCartProduct = new CartProduct
            {
                CartID = cartProduct.CartID,
                ProductID = cartProduct.ProductID,
                Quantity = cartProduct.Quantity
            };
            _context.Entry(cartProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateCartProduct;

        }
    }
}
