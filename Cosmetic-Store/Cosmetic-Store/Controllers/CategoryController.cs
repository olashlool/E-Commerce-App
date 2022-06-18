using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cosmetic_Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        private readonly IProduct _product;

        public CategoryController(ICategory category, IProduct product)
        {
            _category = category;
            _product = product;
        }
        public async Task<IActionResult> Index()
        {
            var listOfCategories = await _category.GetCategories();
            return View(listOfCategories);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var category = await _category.GetCategoryById(id);
            return View(category);
        }
        public async Task<IActionResult> DetailProduct(int id)
        {
            var product = await _product.GetProductById(id);
            return View(product);
        }
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _category.CreateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {

            Category category = await _category.GetCategoryById(id);
            return View(category);
        }
        [Authorize(Roles = "editor")]
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await _category.UpdateCategory(category.CategoryId, category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _category.GetCategoryById(id);
            return View(category);
        }
        [Authorize(Roles = "administrator")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _category.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
