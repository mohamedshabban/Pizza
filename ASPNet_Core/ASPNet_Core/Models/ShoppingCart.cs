using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNet_Core.Models
{
    public class ShoppingCart
    {
        private readonly AppDBContext _appDbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //check if i have active session cart id or create a new one
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;//access all collection of request in session

            var context = services.GetService<AppDBContext>();
            //get cart id or create a new 
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.
                        SingleOrDefault(
                        s => s.Product.ProductId == product.ProductId
                             && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem =
                _appDbContext.
                    ShoppingCartItems.SingleOrDefault(
                        s => s.Product.ProductId == product.ProductId
                             && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            
            return ShoppingCartItems ??= _appDbContext.ShoppingCartItems.
                Where(c => c.ShoppingCartId == ShoppingCartId).
                Include(s => s.Product)
                .ToList();
        }

        public void ClearCart()
        {
            var cartItems =
                _appDbContext
                .ShoppingCartItems
                .Where(sp => sp.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            return _appDbContext.
                ShoppingCartItems.
                Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
        }

    }
}