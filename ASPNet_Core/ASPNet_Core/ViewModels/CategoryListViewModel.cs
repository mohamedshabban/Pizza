using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNet_Core.Models;

namespace ASPNet_Core.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category>categories { get; set; }
    }
}
