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
        private CosmeticDBContext _context;
        public ProductServices(CosmeticDBContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProduct(Product product )
        {
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(int id, Product product)
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
