using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore_Razor.Repositories;

namespace SportsStore_Razor.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository repo)
        {
            _productRepository = repo;
        }
        public ViewResult List() => View(_productRepository.Products);
    }
}