using Microsoft.EntityFrameworkCore;
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
        public  Category AddCategory(Category product)
        {
             _dbContext.Categories.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public Category DeleteCategoryById(int id)
        {
            var categoryToDelete =  _dbContext.Categories.Find(id);
            if (categoryToDelete != null){
                _dbContext.Categories.Remove(categoryToDelete);
                _dbContext.SaveChanges();
            }
            return categoryToDelete;
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories =  _dbContext.Categories.ToList();
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category =  _dbContext.Categories.Find(id);
            return category;

        }

        public  Category UpdateCategory(Category product)
        {
            var category =  _dbContext.Categories.Find(product.Id);

            if (category != null || category.Id > 0)
            {
                category.Name = product.Name;
                category.DisplayOrder = product.DisplayOrder;
            }

            _dbContext.Categories.Update(category);
             _dbContext.SaveChanges();

            return category;
        }
    }
}
