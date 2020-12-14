using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore_Razor.Repositories;
using SportsStore_Razor.ViewModels;

namespace SportsStore_Razor.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            _productRepository = repo;
        }
        public ViewResult List(int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = _productRepository.Products
                            .OrderBy(p => p.ProductID)
                            .Skip((productPage - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _productRepository.Products.Count()
                }
            });
    }
}