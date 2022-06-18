using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cosmetic_Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        public async Task<IActionResult> Index()
        {
            var listOfProducts = await _product.GetProducts();
            return View(listOfProducts);
        }
        public async Task<IActionResult> Detail(int id)
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
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _product.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public async Task<IActionResult> Edit(int id)    
        {
            Product updateProduct = await _product.GetProductById(id);
            return View(updateProduct);
        }
        [Authorize(Roles = "editor")]
        [HttpPost]
        // -http://localhost:22304/Product/Update?id=11
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _product.UpdateProduct(product.ProductId, product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        // -http://localhost:22304/Product/Delete?id=11
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _product.GetProductById(id);
            return View(product);
        }
        [Authorize(Roles = "administrator")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _product.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
