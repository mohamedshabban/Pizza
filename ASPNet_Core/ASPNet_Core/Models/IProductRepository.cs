using System.Collections.Generic;

namespace ASPNet_Core.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get;  }
        Product GetProductById(int productId);
        IEnumerable<Product>ProductOfTheWeek { get; }
        IEnumerable<Product> GetProductByName(string productName);
        IEnumerable<Product> GetProductByGenre(string productName);

    }
}