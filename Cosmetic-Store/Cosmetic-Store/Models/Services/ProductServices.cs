using Cosmetic_Store.Data;
using Cosmetic_Store.Models.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Services
{
    public class ProductServices : IProduct
    {
        // Establishes a private connection to a database via dependency injection
        private CosmeticDBContext _context;
        public ProductServices(CosmeticDBContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProduct(Product product) // Creates a product data by saving a Product object into the connected database
        {
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id) // Deletes a product data based on the id from the connected database
        {
            var product = await GetProductById(id);
            _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id) // Gets a product data based on the id from the connencted database
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<List<Product>> GetProducts() // Gets all of the product data from the connencted database
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(int id, Product product) // Update a product data from the connected database
        {
            var updateProduct = new Product
            {
                ProductId = product.ProductId,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                ImageURL = product.ImageURL
            };
            _context.Entry(updateProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateProduct;
        }
    }
}
