using SportsStore_Razor.Extensions;
using SportsStore_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SportsStore_Razor.Tests
{
    public class CarTests
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            //assert
            Product p1 = new Product { ProductID = Guid.NewGuid().Int2Guid(1), Name = "P1" };
            Product p2 = new Product { ProductID = Guid.NewGuid().Int2Guid(2), Name = "P2" };
            Cart target = new Cart();

            //act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] results = target.Lines.ToArray();

            //assert
            Assert.Equal(p1, results[0].Product);
            Assert.Equal(p2, results[1].Product);
        }
        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            //assert
            Product p1 = new Product { ProductID = Guid.NewGuid().Int2Guid(1), Name = "P1" };
            Product p2 = new Product { ProductID = Guid.NewGuid().Int2Guid(2), Name = "P2" };
            Cart target = new Cart();

            //act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
            CartLine[] results = target.Lines.OrderBy(c => c.Product.ProductID).ToArray();

            //assert
            Assert.Equal(2, results.Length);
            Assert.Equal(4, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }
    }
}
