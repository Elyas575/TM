using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        public Task<ShoppingCart> AddShoppingCartAsync(ShoppingCart obj)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> DeleteShoppingCartByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> GetShoppingCartByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCart>> GetShoppingCartsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCart obj)
        {
            throw new NotImplementedException();
        }
    }
}
