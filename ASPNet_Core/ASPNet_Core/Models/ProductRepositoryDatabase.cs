using System.Collections.Generic;
using System.Linq;

namespace ASPNet_Core.Models
{
    public class ProductRepositoryDatabase:IProductRepository
    {
        private readonly AppDBContext _appDbContext;

        public ProductRepositoryDatabase(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> AllProducts => _appDbContext.Products;
        public Product GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
            
        }

        public IEnumerable<Product> ProductOfTheWeek =>
            _appDbContext.Products.
                OrderBy(p => p.Name).Where(p => p.IsProductOfTheWeek == true);
        public IEnumerable<Product> GetProductByName(string productName)
        {
            return _appDbContext.Products.Where(p => p.Name == productName);
        }

        public IEnumerable<Product> GetProductByGenre(string productName)
        {
            throw new System.NotImplementedException();
        }
    }
}