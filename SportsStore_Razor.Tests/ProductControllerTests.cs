using Moq;
using SportsStore_Razor.Controllers;
using SportsStore_Razor.Models;
using SportsStore_Razor.Repositories;
using SportsStore_Razor.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using SportsStore_Razor.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore_Razor.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = Guid.NewGuid().Int2Guid(1), Name="P1"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(2), Name="P2"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(3), Name="P3"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(4), Name="P4"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(5), Name="P5"}
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //act
            var result = controller.List(null, 2).ViewData.Model as ProductsListViewModel;
             
            //assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = Guid.NewGuid().Int2Guid(1), Name="P1"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(2), Name="P2"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(3), Name="P3"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(4), Name="P4"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(5), Name="P5"}
            }).AsQueryable<Product>());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //act
            var result = controller.List(null, 2).ViewData.Model as ProductsListViewModel;

            //assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
        [Fact]
        public void Can_Filter()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = Guid.NewGuid().Int2Guid(1), Name="P1", Category = "Cat1"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(2), Name="P2", Category = "Cat2"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(3), Name="P3", Category = "Cat3"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(4), Name="P4", Category = "Cat2"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(5), Name="P5", Category = "Cat4"}
            }).AsQueryable<Product>());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //act
            var result = (controller.List("Cat2", 1).ViewData.Model as ProductsListViewModel).Products.ToArray();

            //assert
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");
        }
        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
            //arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns((new Product[]
            {
                new Product {ProductID = Guid.NewGuid().Int2Guid(1), Name="P1", Category = "Cat1"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(2), Name="P2", Category = "Cat2"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(3), Name="P3", Category = "Cat3"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(4), Name="P4", Category = "Cat2"},
                new Product {ProductID = Guid.NewGuid().Int2Guid(5), Name="P5", Category = "Cat4"}
            }).AsQueryable<Product>());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            Func<ViewResult, ProductsListViewModel> GetModel = result =>
                result?.ViewData?.Model as ProductsListViewModel;
            //act 
            int? res1 = GetModel(controller.List("Cat1"))?.PagingInfo.TotalItems;
            var res2 = (controller.List("Cat2", 1).ViewData.Model as ProductsListViewModel).PagingInfo.TotalItems;
            //assert
            Assert.Equal(1, res1);
            Assert.Equal(2, res2);

        }
    }
}
