using System.Collections.Generic;
using System.Linq;

namespace ASPNet_Core.Models
{
    public class MemoryProductRepository:IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository;

        public MemoryProductRepository(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IEnumerable<Product> AllProducts=>
            new List<Product>
            {
                new Product
                {
                    ProductId = 1,Name = "Pizza 1",ShortDescription = "Jacket" ,LongDescription = "Jacket is the base of Winter",
                    AllergyInformation = "",Price = 400M,
                    ImageThumbnailUrl = "",IsProductOfTheWeek = false,InStock = true,
                    CategoryId = 1,Category = _categoryRepository.AllCategories.ToList()[0]
                    ,ImageUrl = "~/../../Images/1.jpg"
                },new Product
                {
                    ProductId = 2,Name = "Pizza 2",ShortDescription = "Jacket" ,LongDescription = "Jacket is the base of Winter",
                    AllergyInformation = "",Price = 400M,
                    ImageThumbnailUrl = "",IsProductOfTheWeek = false,InStock = true,
                    CategoryId = 2,Category = _categoryRepository.AllCategories.ToList()[0]
                    ,ImageUrl = "~/../../Images/1.jpg"
                },new Product
                {
                    ProductId = 3,Name = "Pizza 3",ShortDescription = "Jacket" ,LongDescription = "Jacket is the base of Winter",
                    AllergyInformation = "",Price = 400M,
                    ImageThumbnailUrl = "",IsProductOfTheWeek = false,InStock = true,
                    CategoryId = 3,Category = _categoryRepository.AllCategories.ToList()[0]
                    ,ImageUrl = "~/../../Images/1.jpg"
                },new Product
                {
                    ProductId = 4,Name = "Pizza 4",ShortDescription = "Jacket" ,LongDescription = "Jacket is the base of Winter",
                    AllergyInformation = "",Price = 400M,
                    ImageThumbnailUrl = "",IsProductOfTheWeek = true,InStock = true,
                    CategoryId = 4,Category = _categoryRepository.AllCategories.ToList()[0]
                    ,ImageUrl = "~/../../Images/1.jpg"
                },new Product
                {
                    ProductId = 5,Name = "Pizza 5",ShortDescription = "Jacket" ,LongDescription = "Jacket is the base of Winter",
                    AllergyInformation = "",Price = 400M,
                    ImageThumbnailUrl = "",IsProductOfTheWeek = false,InStock = true,
                    CategoryId = 5,Category = _categoryRepository.AllCategories.ToList()[0]
                    ,ImageUrl = "~/../../Images/1.jpg"
                },
                new Product
                {
                    ProductId = 6,Name = "Pizza 6",ShortDescription = "Jacket" ,LongDescription = "Jacket is the base of Winter",
                    AllergyInformation = "",Price = 400M,
                    ImageThumbnailUrl = "",IsProductOfTheWeek = false,InStock = true,
                    CategoryId = 1,Category = _categoryRepository.AllCategories.ToList()[0]
                    ,ImageUrl = "~/../../Images/1.jpg"
                } ,new Product
                {
                    ProductId = 7,Name = "Pizza 7",ShortDescription = "Jacket" ,LongDescription = "Jacket is the base of Winter",
                    AllergyInformation = "",Price = 400M,
                    ImageThumbnailUrl = "",IsProductOfTheWeek = false,InStock = true,
                    CategoryId = 2,Category = _categoryRepository.AllCategories.ToList()[0]
                    ,ImageUrl = "~/../../Images/1.jpg"
                } , new Product
                {
                    ProductId = 8,Name = "Pizza 8",ShortDescription = "Jacket" ,LongDescription = "Jacket is the base of Winter",
                    AllergyInformation = "",Price = 400M,
                    ImageThumbnailUrl = "",IsProductOfTheWeek = true,InStock = true,
                    CategoryId = 3,Category = _categoryRepository.AllCategories.ToList()[0]
                    ,ImageUrl = "~/../../Images/1.jpg"
                },  new Product
                {
                    ProductId = 9,Name = "Pizza 9",ShortDescription = "Jacket" ,LongDescription = "Jacket is the base of Winter",
                    AllergyInformation = "",Price = 400M,
                    ImageThumbnailUrl = "",IsProductOfTheWeek = true,InStock = true,
                    CategoryId = 4,Category = _categoryRepository.AllCategories.ToList()[0]
                    ,ImageUrl = "~/../../Images/1.jpg"
                }
            };
        
        public Product GetProductById(int productId)
        {
            return AllProducts.FirstOrDefault(p => p.ProductId == productId);
        }

        public IEnumerable<Product> ProductOfTheWeek { get; }
        public IEnumerable<Product> GetProductByName(string name = null)
        {
            //Query
            return from p in AllProducts
                where string.IsNullOrEmpty(name) ||
                      p.Name.StartsWith(name) || p.Name.Contains(name)
                select p;
        }

        public IEnumerable<Product> GetProductByGenre(string productName)
        {
            throw new System.NotImplementedException();
        }
    }
}