using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.DataAccess.IRepository.CategoryRepository;
using ThursdayMarket.DataAccess.IRepository.IShoppingCartRepository;
using ThursdayMarket.Models;
using ThursdayMarket.Models.ViewModels;

namespace ThursdayMarket.DataAccess.Repository.ShoppingCartRepository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShoppingCartRepository(ApplicationDbContext dbContext)
        {  
            _dbContext = dbContext;
        }

        public async Task<ShoppingCart> AddShoppingCartAsync(ShoppingCart obj)
        {
     
            await _dbContext.ShoppingCart.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<ShoppingCart> DeleteShoppingCartByIdAsync(int id)
        {
            var shoppingCartToDelete = await _dbContext.ShoppingCart.FindAsync(id);
            if (shoppingCartToDelete != null)
            {
                _dbContext.ShoppingCart.Remove(shoppingCartToDelete);
                await _dbContext.SaveChangesAsync();
            }
            return shoppingCartToDelete;
        }
        public async Task<ShoppingCart> GetShoppingCartByIdAsync(int cartId)
        {
            var cartFromDb = await _dbContext.ShoppingCart.Include(x=>x.Product).FirstOrDefaultAsync(u => u.Id == cartId);
            return cartFromDb;
        }
        public async Task<List<ShoppingCart>> GetShoppingCartsAsync(string applicationUserId)
        {
            var cartsFromDb = await _dbContext.ShoppingCart
                .Where(u => u.ApplicationUserId == applicationUserId)
                .Include(u=>u.Product)
                .ToListAsync();

            return cartsFromDb;
        }

        public async Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCart obj)
        {

            var ExistingShoppingCart = await _dbContext.ShoppingCart.FindAsync(obj.Id);

    /*        if (ExistingShoppingCart != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.DisplayOrder = category.DisplayOrder;
            }*/

            await _dbContext.SaveChangesAsync();

            return ExistingShoppingCart;
        }

        public async Task<ShoppingCart> GetShoppingCartAsync(string applicationUserId, int productId)
        {
            var cartFromDb = await _dbContext.ShoppingCart.FirstOrDefaultAsync(u => u.ApplicationUserId == applicationUserId && u.ProductId == productId);
            return cartFromDb;
        }

        public Task<ShoppingCart> AddOrUpdateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}
