using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThursdayMarket.DataAccess.IRepository.CategoryRepository;
using ThursdayMarket.DataAccess.IRepository.ProductRepository;
using ThursdayMarket.Models;
using ThursdayMarket.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThursdayMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetProductsAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (product != null)
            {
                await _productRepository.AddProductAsync(product);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<SelectListItem> categoryList = (await _categoryRepository.GetCategoriesAsync())
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            ProductVM productVM = new()
            {
                CategoryList = categoryList,
                Product = new Product()
            };

            ViewBag.CategoryList = categoryList;
            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductVM obj)
        {
            if (obj != null)
            {
                await _productRepository.UpdateProductAsync(obj.Product);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            IEnumerable<SelectListItem> categoryList = (await _categoryRepository.GetCategoriesAsync())
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            ProductVM productVM = new()
            {
                CategoryList = categoryList,
                Product = product
            };

            ViewBag.CategoryList = categoryList;

            return View(productVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.DeleteProductByIdAsync(id);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}