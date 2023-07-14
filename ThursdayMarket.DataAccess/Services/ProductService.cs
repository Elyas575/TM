using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.DataAccess.IRepository.ProductRepository;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public  ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public  Product AddProduct(Product product)
        {
            return  _productRepository.AddProduct(product);
        }

        public  Product DeleteProductById(int id)
        {
            return  _productRepository.DeleteProductById(id);
        }

        public Product GetProductById(int id)
        {
            return  _productRepository.GetProductById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return  _productRepository.GetProducts();
        }

        public Product UpdateProduct(Product product)
        {
            return  _productRepository.UpdateProduct(product);
        }
    }
}
