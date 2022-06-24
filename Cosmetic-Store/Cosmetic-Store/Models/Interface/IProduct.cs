using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Interface
{
    public interface IProduct
    {
        // Create
        public Task<Product> CreateProduct(Product product);

        // Read - GetByID
        public Task<Product> GetProductById(int id);

        // Read - GetAll
        public Task<List<Product>> GetProducts();
        
        // Update
        public Task<Product> UpdateProduct(int id, Product product);
        
        // Delete
        public Task DeleteProduct(int id);

    }
}
