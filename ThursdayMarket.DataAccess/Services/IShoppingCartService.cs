using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Services
{
    public interface IShoppingCartService
    {
        Task<IEnumerable<ShoppingCart>> GetShoppingCartsAsync();
        Task<ShoppingCart> GetShoppingCartByIdAsync(string id);
        Task<ShoppingCart> DeleteShoppingCartByIdAsync(string id);
        Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCart obj);
        Task<ShoppingCart> AddShoppingCartAsync(ShoppingCart obj);
    }
}
