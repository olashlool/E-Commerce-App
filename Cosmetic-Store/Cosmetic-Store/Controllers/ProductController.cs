using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Interface;
using Cosmetic_Store.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace Cosmetic_Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly ICategory _category;

        private readonly IConfiguration _configuration;

        public ProductController(IProduct product, IConfiguration configuration, ICategory category)
        {
            _product = product;
            _configuration = configuration;
            _category = category;
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create()
        {
            ProductVM viewModel = new ProductVM
            {
                Categories = await _category.GetCategories()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile file)
        {
            BlobContainerClient container = new BlobContainerClient(_configuration.GetConnectionString("AzureBlob"), "images");
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();

            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            };
            if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }

            product.ImageURL = blob.Uri.ToString();
            stream.Close();
            if (ModelState.IsValid)
            {
                await _product.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)    
        {
            Product updateProduct = await _product.GetProductById(id);
            var pro = new ProductVM
            {
                Name = updateProduct.Name,
                Price = updateProduct.Price,
                Description = updateProduct.Description,
                CategoryId = updateProduct.CategoryId,
                ImageUrl = updateProduct.ImageURL,
                Categories = await _category.GetCategories()
            };
            return View(pro);
        }
        [HttpPost]
        // -http://localhost:22304/Product/Update?id=11
        public async Task<IActionResult> Edit(Product product, IFormFile file)
        {
            BlobContainerClient container = new BlobContainerClient(_configuration.GetConnectionString("AzureBlob"), "images");
            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();

            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            };
            if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }

            product.ImageURL = blob.Uri.ToString();
            stream.Close();
            if (ModelState.IsValid)
            {
                await _product.UpdateProduct(product.ProductId, product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        // -http://localhost:22304/Product/Delete?id=11
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _product.GetProductById(id);
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _product.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
