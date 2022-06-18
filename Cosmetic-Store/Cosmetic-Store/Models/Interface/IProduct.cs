using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Interface
{
    public interface IProduct
    {
        public Task<Product> CreateProduct(Product product);
        public Task<Product> GetProductById(int id);
        public Task<List<Product>> GetProducts();
        public Task<Product> UpdateProduct(int id, Product product);
        public Task DeleteProduct(int id);
    }
}
