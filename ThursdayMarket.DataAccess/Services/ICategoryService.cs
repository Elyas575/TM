using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Services
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetCategories();
        public Category GetCategoryById(int id);
        public Category DeleteCategoryById(int id);
        public Category UpdateCategory(Category product);
        public Category AddCategory(Category product);
    }
}
