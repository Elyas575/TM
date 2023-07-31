using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThursdayMarket.DataAccess.IRepository.CategoryRepository;
using ThursdayMarket.DataAccess.IRepository.ProductRepository;
using ThursdayMarket.Models;
using ThursdayMarket.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using ThursdayMarket.Utility;
using ThursdayMarket.DataAccess.Services;

namespace ThursdayMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productService.GetProductsAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (product != null)
            {
                await _productService.AddProductAsync(product);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<SelectListItem> categoryList = (await _categoryService.GetCategoriesAsync())
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
                await _productService.UpdateProductAsync(obj.Product);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> categoryList = (await _categoryService.GetCategoriesAsync())
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

            var product = await _productService.GetProductByIdAsync(id);

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
                await _productService.DeleteProductByIdAsync(id);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}