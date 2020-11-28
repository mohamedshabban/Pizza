using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNet_Core.Models;
namespace ASPNet_Core.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> ProductsOfTheWeek { get; set; }
    }
}
