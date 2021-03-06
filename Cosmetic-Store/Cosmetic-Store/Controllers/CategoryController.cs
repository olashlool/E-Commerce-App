using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Cosmetic_Store.Models;
using Cosmetic_Store.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Cosmetic_Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        private readonly IConfiguration _configuration;


        public CategoryController(ICategory category, IConfiguration configuration)
        {
            _category = category;
            _configuration = configuration; 
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
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category, IFormFile file)
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

            category.Logo = blob.Uri.ToString();
            stream.Close();
            if (ModelState.IsValid)
            {
                await _category.CreateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {

            Category category = await _category.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category, IFormFile file)
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

            category.Logo = blob.Uri.ToString();
            stream.Close();
            if (ModelState.IsValid)
            {
                await _category.UpdateCategory(category.CategoryId, category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _category.GetCategoryById(id);
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _category.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
