using System.Collections.Generic;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.IRepository.IShoppingCartRepository
{
        public interface IShoppingCartRepository
        {
        public  Task<ShoppingCart> GetShoppingCartByIdAsync(int cartId);
        public Task<List<ShoppingCart>> GetShoppingCartsAsync(string applicationUserId);
        public Task<ShoppingCart> GetShoppingCartAsync(string applicationUserId, int productId);
        public Task<ShoppingCart> DeleteShoppingCartByIdAsync(int id);
        public Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCart obj);
        public Task<ShoppingCart> AddShoppingCartAsync(ShoppingCart obj);
    }
}