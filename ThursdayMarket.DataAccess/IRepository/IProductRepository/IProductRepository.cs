using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.IRepository.ProductRepository
{
    public interface IProductRepository
    {
        public  Task<IEnumerable<Product>> GetProductsAsync();
        public  Task<Product> GetProductByIdAsync(int id);
        public  Task<Product> DeleteProductByIdAsync(int id);
        public Task<Product> UpdateProductAsync(Product product);
        public Task<Product> AddProductAsync(Product product);
    }
}