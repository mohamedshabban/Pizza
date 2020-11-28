using System.Collections.Generic;

namespace ASPNet_Core.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category>AllCategories { get; }

    }
}