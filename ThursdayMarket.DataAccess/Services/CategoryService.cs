using System.Collections.Generic;
using System.Threading.Tasks;
using ThursdayMarket.DataAccess.IRepository.CategoryRepository;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            return await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task<Category> DeleteCategoryByIdAsync(int id)
        {
            return await _categoryRepository.DeleteCategoryByIdAsync(id);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            return await _categoryRepository.UpdateCategoryAsync(category);
        }
    }
}