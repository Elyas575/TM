using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.DataAccess.IRepository.ProductRepository;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public  Product AddProduct(Product obj)
        {
            if (obj == null){
                throw new ArgumentNullException();
            }
            _context.Products.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public  Product DeleteProductById(int id)
        {
            Product productToDelete =  _context.Products.Find(id);
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();

            return productToDelete;
        }

        public Product GetProductById(int id)
        {

           Product product = _context.Products.Find(id);
           return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products =  _context.Products.ToList();
            return products;
        }

        public Product UpdateProduct(Product product)
        {

             _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}
