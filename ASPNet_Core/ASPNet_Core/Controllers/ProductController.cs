using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNet_Core.Models;
using ASPNet_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPNet_Core.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

       
        public IActionResult List()
        {
            var productList=new ProductList();
            productList.GetProducts = _productRepository.AllProducts.OrderBy(p => p.Name);
            if (productList.GetProducts.Count() == 0)
                return NotFound();
            return View(productList);
        }

        //public IActionResult List(string category,int x=0)
        //{
        //    var categoryList = new CategoryListViewModel
        //    {
        //        categories = _categoryRepository.AllCategories
        //            .OrderBy(p => p.CategoryName)
        //    };

        //    if (!String.IsNullOrEmpty(category))
        //    {
        //        categoryList.categories = categoryList.categories.Where(s => s.CategoryName.Contains(category));
        //    }
        //    else
        //    {
        //        categoryList.categories = _categoryRepository.AllCategories.OrderBy(p => p.CategoryName);
        //    }

        //    return View(categoryList);
        //}
        [HttpPost]
        public IActionResult List(string searchString)
        {
            var productList = new ProductList
            {
                GetProducts = _productRepository.
                    AllProducts.OrderBy(p => p.Name)
            };
            
            if (!String.IsNullOrEmpty(searchString))
            {
                productList.GetProducts = productList.
                    GetProducts.Where(s => s.Name.Contains(searchString));
            }
            else
            {
                productList.GetProducts = _productRepository.AllProducts.OrderBy(p => p.Name);
                return View(productList);
            }

            return View(productList);
        }
        public IActionResult Details(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null)
                return NotFound();
            return View(product);
        }
        

    }
}
