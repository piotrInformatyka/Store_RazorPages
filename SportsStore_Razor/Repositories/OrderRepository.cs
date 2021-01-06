using Microsoft.EntityFrameworkCore;
using SportsStore_Razor.Data;
using SportsStore_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore_Razor.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext _context;



        public OrderRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public IQueryable<Order> Orders => _context.Orders.Include(x => x.Lines).ThenInclude(p => p.Product);
        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if(order.OrderId == 0)
            {
                _context.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
