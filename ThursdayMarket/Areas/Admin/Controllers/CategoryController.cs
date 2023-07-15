using Microsoft.AspNetCore.Mvc;
using ThursdayMarket.DataAccess.IRepository.CategoryRepository;
using ThursdayMarket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetCategoriesAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category item)
        {
            await _categoryRepository.AddCategoryAsync(item);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Category category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category item)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateCategoryAsync(item);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Category category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.DeleteCategoryByIdAsync(id);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}