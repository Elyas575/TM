using System.Collections.Generic;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.IRepository.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> DeleteCategoryByIdAsync(int id);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<Category> AddCategoryAsync(Category category);
    }
}