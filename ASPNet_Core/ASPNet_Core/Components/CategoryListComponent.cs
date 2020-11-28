using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNet_Core.Models;
using ASPNet_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPNet_Core.Components
{
    public class CategoryListComponent:ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryListComponent(ICategoryRepository categoryRepository )
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var viewmodel=new CategoryListViewModel();

            viewmodel.categories = _categoryRepository.AllCategories;
            return View(viewmodel);
        }
    }
}
