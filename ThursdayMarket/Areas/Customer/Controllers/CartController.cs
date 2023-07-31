using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ThursdayMarket.DataAccess.IRepository.IShoppingCartRepository;
using ThursdayMarket.DataAccess.Services;
using ThursdayMarket.Models;
using ThursdayMarket.Models.ViewModels;

namespace ThursdayMarket.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        /*        private readonly IShoppingCartService _shoppingCartService;*/
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartVM ShoppingCartVM { get; set; }

        public CartController(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = await _shoppingCartRepository.GetShoppingCartsAsync(userId)
            };

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _shoppingCartRepository.DeleteShoppingCartByIdAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Summary()
        {
            return View();
        }

        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            return shoppingCart.Product.Price;
        }
    }
}
