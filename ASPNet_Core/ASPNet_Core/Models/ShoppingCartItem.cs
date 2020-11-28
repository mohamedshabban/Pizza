namespace ASPNet_Core.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        //Amount of item added
        public int Amount { get; set; }
        //Product in Shopping Cart
        public Product Product { get; set; }
        public string ShoppingCartId { get; set; }
    }
}