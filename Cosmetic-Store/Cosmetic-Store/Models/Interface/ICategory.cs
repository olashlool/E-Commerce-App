using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Interface
{
    public interface ICategory
    {
        public Task<Category> CreateCategory(Category category);
        public Task<Category> GetCategoryById(int id);
        public Task<List<Category>> GetCategories();
        public Task<Category> UpdateCategory(int id , Category category);
        public Task DeleteCategory(int id);
    }
}
