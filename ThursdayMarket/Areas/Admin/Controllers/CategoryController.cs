using Microsoft.AspNetCore.Mvc;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.DataAccess.IRepository.CategoryRepository;
using ThursdayMarket.DataAccess.IRepository.ProductRepository;
using ThursdayMarket.Models;

namespace ThursdayMarket.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetCategories();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category item)
        {

            _categoryRepository.AddCategory(item);
            return RedirectToAction("Index");

        }


        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category item)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(item);
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var category = _categoryRepository.GetCategoryById(id);
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
                _categoryRepository.DeleteCategoryById(id);
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
