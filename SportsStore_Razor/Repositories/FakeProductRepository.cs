﻿using SportsStore_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_Razor.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{Name = "Piłka nożna", Price = 25},
            new Product{Name = "Deska surfingowa", Price = 179},
            new Product{Name = "Buty do biegania", Price = 95},
        }.AsQueryable<Product>();
    }
}
