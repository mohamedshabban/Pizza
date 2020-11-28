using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNet_Core.Models;
using Microsoft.CodeAnalysis;

namespace ASPNet_Core.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository,ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(OrderForm orderForm)
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            if(_shoppingCart.ShoppingCartItems.Count==0)
            {ModelState.AddModelError("","Your Cart is Empty!");}
            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrderForm(orderForm);
                _shoppingCart.ClearCart();
                
                return RedirectToAction("Index");
            }
            return View(orderForm);
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
