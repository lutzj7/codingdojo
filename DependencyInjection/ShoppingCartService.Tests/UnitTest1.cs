using System;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCartService.Tests
{
    [TestClass]
    public class UnitTest1
    {
        const string ProductId = "#123";
        const string ProductName = "Banana";
        const int ProductPrice = 34;
       
        [TestMethod]
        public void TestMethod1()
        {
            const int productCount = 5;

            var inventoryPersistency = new InventoryPersistencyFake();
            inventoryPersistency.TryAddProduct(new Product(ProductId, ProductName, ProductPrice));

            ShoppingCartService shoppingCartService = new ShoppingCartService(inventoryPersistency, new ShoppingCartPersistency());

            var shoppingCartId = shoppingCartService.CreateCart();
            shoppingCartService.AddToCart(shoppingCartId, ProductId, productCount);

            var response = shoppingCartService.GetShoppingCart(shoppingCartId);

            Assert.AreEqual(ProductPrice * productCount, response.Total);
        }
    }
}
