using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPNet_Core.Models
{
    public class OrderRepository:IOrderRepository
    {
        public AppDBContext _appDbContext { get; set; }
        public  ShoppingCart _shoppingCart { get; set; }

        public OrderRepository(AppDBContext appDbContext,ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrderForm(OrderForm order)
        {
            order.OrderPlaced = DateTime.Now;
            var shoppingCartItems
                = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.ProductId,
                    Price = shoppingCartItem.Product.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _appDbContext.Orders.Add(order);

            _appDbContext.SaveChanges();
        }

       
    }
}