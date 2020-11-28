using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNet_Core.Models;
using ASPNet_Core.ViewModels;

namespace ASPNet_Core.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IProductRepository _productRepository;

        public ShoppingCartController(ShoppingCart shoppingCart,IProductRepository productRepository)
        {
            _shoppingCart = shoppingCart;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            var ViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(ViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var product = _productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
                _shoppingCart.AddToCart(product, 1);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var product = _productRepository.AllProducts.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
                _shoppingCart.RemoveFromCart(product);
            return RedirectToAction("Index");
        }
    }
}
