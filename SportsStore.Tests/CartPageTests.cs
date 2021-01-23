using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Moq;
using NUnit.Framework;
using SportsStore.Models;
using SportsStore.Pages;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace SportsStore.Tests
{
    public class CartPageTests
    {
        [Test]
        public void Can_Load_Cart()
        {
            // Arrange
            // - create a mock repository
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Mock<IStoreRepository> mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(m => m.Products).Returns((new Product[] { p1, p2 }).AsQueryable<Product>());
            // - create a cart
            Cart testCart = new Cart();
            testCart.AddItem(p1, 2);
            testCart.AddItem(p2, 1);

            // Action
            CartModel cartModel = new CartModel(mockRepo.Object, testCart);
            cartModel.OnGet("myUrl");

            //Assert
            Assert.AreEqual(2, cartModel.Cart.Lines.Count());
            Assert.AreEqual("myUrl", cartModel.ReturnUrl);
        }

        [Test]
        public void Can_Update_Cart()
        {
            // Arrange
            // - create a mock repository
            Mock<IStoreRepository> mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(m => m.Products).Returns((new Product[] { new Product { ProductID = 1, Name = "P1" } }).AsQueryable<Product>());
            Cart testCart = new Cart();

            // Action
            CartModel cartModel = new CartModel(mockRepo.Object, testCart);
            cartModel.OnPost(1, "myUrl");

            //Assert
            Assert.That(testCart.Lines, Has.Exactly(1).Items);
            Assert.AreEqual("P1", testCart.Lines.First().Product.Name);
            Assert.AreEqual(1, testCart.Lines.First().Quantity);
        }
    }
}