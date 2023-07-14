using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.IRepository.ProductRepository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProductById(int id);
        public Product DeleteProductById(int id);
        public Product UpdateProduct(Product product);
        public Product AddProduct(Product product);
    }
}
