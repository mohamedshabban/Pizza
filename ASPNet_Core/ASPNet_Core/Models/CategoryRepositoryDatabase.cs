using System.Collections.Generic;

namespace ASPNet_Core.Models
{
    public class CategoryRepositoryDatabase:ICategoryRepository
    {
        private readonly AppDBContext _appDbContext;

        public CategoryRepositoryDatabase(AppDBContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;
    }
}