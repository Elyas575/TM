using System.Collections.Generic;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.IRepository.CategoryRepository
{
    public interface ICategoryRepository
    {
        public  Task<IEnumerable<Category>> GetCategoriesAsync();
        public  Task<Category> GetCategoryByIdAsync(int id);
        public Task<Category> DeleteCategoryByIdAsync(int id);
        public Task<Category> UpdateCategoryAsync(Category category);
        public Task<Category> AddCategoryAsync(Category category);
    }
}