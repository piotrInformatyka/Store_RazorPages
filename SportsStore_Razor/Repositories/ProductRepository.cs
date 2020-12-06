
using SportsStore_Razor.Data;
using SportsStore_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_Razor.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DataContext _context;
        public ProductRepository(DataContext ctx)
        {
            _context = ctx;
        }
        //Wyciek abstrakcji przez zwracanie IQuaryble
        public IQueryable<Product> Products => _context.Products;
    }
}
