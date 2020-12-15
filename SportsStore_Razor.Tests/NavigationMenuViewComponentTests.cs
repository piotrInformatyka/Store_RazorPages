using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SportsStore_Razor.Components;
using SportsStore_Razor.Extensions;
using SportsStore_Razor.Models;
using SportsStore_Razor.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SportsStore_Razor.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Products).Returns((new Product[]
            {
                new Product {ProductID = Guid.NewGuid().Int2Guid(1), Name="P1", Category = "Jabłka"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(2), Name="P2", Category = "Jabłka"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(3), Name="P3", Category = "Śliwki"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(3), Name="P3", Category = "Pomarańcze"},
            }).AsQueryable());
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

            //act
            var result = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();
            //assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Jabłka", "Pomarańcze", "Śliwki"}, result));
            Assert.True(result.Length == 3);
        }

    }
}
