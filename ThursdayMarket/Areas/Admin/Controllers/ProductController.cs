using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThursdayMarket.DataAccess.IRepository.CategoryRepository;
using ThursdayMarket.DataAccess.IRepository.ProductRepository;

using ThursdayMarket.Models;
using ThursdayMarket.Models.ViewModels;

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
        public IActionResult Index()
        {
            IEnumerable<Product> products = _productRepository.GetProducts();

            return View(products);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product != null)
            {
                _productRepository.AddProduct(product);
                return Redirect("Index");
            }

            return View();

        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _categoryRepository.GetCategories().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ProductVM productVM = new()
            {
                CategoryList = CategoryList,
                Product = new Product()
            };

            ViewBag.CategoryList = CategoryList;
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM obj)
        {

            if (obj != null)
            {
                _productRepository.UpdateProduct(obj.Product);
                return RedirectToAction("Index");

            }

            return View();
        }
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);
            IEnumerable<SelectListItem> CategoryList = _categoryRepository.GetCategories().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ProductVM productVM = new()
            {
                CategoryList = CategoryList,
                Product = product
            };

            ViewBag.CategoryList = CategoryList;
            
            return View(productVM);
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var category = _productRepository.GetProductById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            if (ModelState.IsValid)
            {
                _productRepository.DeleteProductById(id);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
