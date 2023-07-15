using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.DataAccess.IRepository.CategoryRepository;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategoryByIdAsync(int id)
        {
            var categoryToDelete = await _dbContext.Categories.FindAsync(id);
            if (categoryToDelete != null)
            {
                _dbContext.Categories.Remove(categoryToDelete);
                await _dbContext.SaveChangesAsync();
            }
            return categoryToDelete;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await _dbContext.Categories
                .Include( c => c.Products)
                .ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _dbContext.Categories.FindAsync(category.Id);

            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.DisplayOrder = category.DisplayOrder;
            }

            await _dbContext.SaveChangesAsync();

            return existingCategory;
        }
    }
}