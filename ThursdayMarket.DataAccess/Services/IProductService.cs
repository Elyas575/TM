using System.Collections.Generic;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> DeleteProductByIdAsync(int id);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> AddProductAsync(Product product);
    }
}