using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThursdayMarket.DataAccess.IRepository.CategoryRepository;
using ThursdayMarket.DataAccess.Services;
using ThursdayMarket.Models;

namespace ThursdayMarket.Areas.Customer.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
    
        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IProductService productService)
        {
            _productService = productService;
            _logger = logger;

        }

        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
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