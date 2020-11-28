using System.Collections.Generic;

namespace ASPNet_Core.Models
{
    public class MemoryCategoryRepository:ICategoryRepository
    {
        public  IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId = 1,CategoryName = "Category 1",Description = "Category 1"},
                new Category{CategoryId = 2,CategoryName = "Category 2",Description = "Category 2"},
                new Category{CategoryId = 3,CategoryName = "Category 3",Description = "Category 3"},
                new Category{CategoryId = 4,CategoryName = "Category 4",Description = "Category 4"},
                new Category{CategoryId = 5,CategoryName = "Category 5",Description = "Category 5"},
            };   
    }
}