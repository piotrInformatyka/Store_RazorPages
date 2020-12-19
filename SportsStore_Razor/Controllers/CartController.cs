using Microsoft.AspNetCore.Mvc;
using SportsStore_Razor.Infrastructure;
using SportsStore_Razor.Models;
using SportsStore_Razor.Repositories;
using SportsStore_Razor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_Razor.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _productRepository;
        private Cart _cart;
        public CartController(IProductRepository repo, Cart cartService)
        {
            _productRepository = repo;
            _cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(Guid productId, string returnUrl)
        {
            Product product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(Guid productId, string returnUrl)
        {
            Product product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
