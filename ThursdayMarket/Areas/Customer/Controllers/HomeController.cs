using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using ThursdayMarket.DataAccess.IRepository;
using ThursdayMarket.DataAccess.IRepository.IShoppingCartRepository;
using ThursdayMarket.DataAccess.Repository.ApplicationUserRepository;
using ThursdayMarket.DataAccess.Services;
using ThursdayMarket.Models;
using ThursdayMarket.Models.ViewModels;

namespace ThursdayMarket.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IProductService productService, IShoppingCartRepository shoppingCartRepository, IApplicationUserRepository applicationUserRepository)
        {
            _logger = logger;
            _categoryService = categoryService;
            _productService = productService;
            _shoppingCartRepository = shoppingCartRepository;
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            ShoppingCart shoppinCart = new ShoppingCart()
            {
                Product = product,
                ProductId = id,
                Count = 1


            };
            return View(shoppinCart);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            var product = await _productService.GetProductByIdAsync(shoppingCart.ProductId);
            shoppingCart.ProductId = product.Id;

            ShoppingCart cartFromDb = await _shoppingCartRepository.GetShoppingCartAsync(userId, shoppingCart.ProductId);

            if (cartFromDb != null)
            {
                cartFromDb.Count += shoppingCart.Count;
                await _shoppingCartRepository.UpdateShoppingCartAsync(cartFromDb);
            }
            else
            {
                ShoppingCart Lmao = new ShoppingCart() {
                    ProductId = shoppingCart.ProductId,
                    Count = shoppingCart.Count,
                    ApplicationUserId   = userId
                
                };
                await _shoppingCartRepository.AddShoppingCartAsync(Lmao);
            }
            return RedirectToAction("Index");
        }


        public IActionResult Remove(int cartId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var cartFromDb = _shoppingCartRepository.GetShoppingCartByIdAsync(cartId);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}