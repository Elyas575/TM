using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Product> AddProductAsync(Product obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            _context.Products.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Product> DeleteProductByIdAsync(int id)
        {
            Product productToDelete = await _context.Products.FindAsync(id);
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();

            return productToDelete;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            IEnumerable<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}