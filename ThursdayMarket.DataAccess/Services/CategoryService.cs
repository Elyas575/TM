using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Category AddCategory(Category product)
        {
          return  _categoryRepository.AddCategory(product);
        }

        public Category DeleteCategoryById(int id)
        {
            return  _categoryRepository.DeleteCategoryById(id);
        }

        public  IEnumerable<Category> GetCategories()
        {
            return  _categoryRepository.GetCategories();
        }

        public  Category GetCategoryById(int id)
        {
           return  _categoryRepository.GetCategoryById(id);
        }

        public  Category UpdateCategory(Category product)
        {
            return  _categoryRepository.UpdateCategory(product);
        }
    }
}
