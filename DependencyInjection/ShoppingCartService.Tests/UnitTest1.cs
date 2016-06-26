using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCartService.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var shoppingCartService = new ShoppingCartService();
            var shoppingCartId = shoppingCartService.CreateCart();
            shoppingCartService.AddToCart(shoppingCartId, "#123", 5);

            var response = shoppingCartService.GetShoppingCart(shoppingCartId);

            Assert.AreEqual(170, response.Total);
        }
    }
}
