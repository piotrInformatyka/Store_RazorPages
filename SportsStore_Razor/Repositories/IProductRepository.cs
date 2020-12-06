using SportsStore_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_Razor.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
