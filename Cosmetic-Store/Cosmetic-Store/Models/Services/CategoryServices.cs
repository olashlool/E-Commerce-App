using Cosmetic_Store.Data;
using Cosmetic_Store.Models.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Services
{
    public class CategoryServices : ICategory
    {
        // Establishes a private connection to a database via dependency injection
        private readonly CosmeticDBContext _context;
        public CategoryServices(CosmeticDBContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategories() // Gets all of the categories data from the connencted database
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryById(int id) // Gets a category data based on the id from the connencted database
        {
            return await _context.Categories.Include(x=>x.Products).FirstOrDefaultAsync(x => x.CategoryId == id);
        }
        public async Task<Category> CreateCategory(Category category) // Creates a category data by saving a Category object into the connected database
        {
            _context.Entry(category).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task DeleteCategory(int id) // Deletes a category data based on the id from the connected database
        {
            Category category = await GetCategoryById(id);
            _context.Entry(category).State= EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Category> UpdateCategory(int id, Category category) // Update a category data from the connected database
        {
            var updateCategory = new Category
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                Logo = category.Logo 
            };
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateCategory;
        }
    }
}
