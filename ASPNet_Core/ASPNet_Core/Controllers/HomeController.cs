using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPNet_Core.Models;
using ASPNet_Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNet_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger,IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var homeView = new HomeViewModel();
            homeView.ProductsOfTheWeek = 
                _productRepository.AllProducts.OrderBy(p => p.Name)
                .Where(p => p.IsProductOfTheWeek == true);
            if (homeView == null)
                return NotFound();
            return View(homeView);
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
