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
            
            ShoppingCartService shoppingCartService = CreateShoppingCartService();

            var shoppingCartId = shoppingCartService.CreateCart();
            shoppingCartService.AddToCart(shoppingCartId, ProductId, productCount);

            var response = shoppingCartService.GetShoppingCart(shoppingCartId);

            Assert.AreEqual(ProductPrice * productCount, response.Total);
        }

        private static ShoppingCartService CreateShoppingCartService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<ShoppingCartServiceModule>();

            builder.Register((ctx) => {
                var inventoryPersistencyFake = new InventoryPersistencyFake();
                inventoryPersistencyFake.TryAddProduct(new Product(ProductId, ProductName, ProductPrice));
                return inventoryPersistencyFake;
            })
                .As<IInventoryPersistency>();

            var container = builder.Build();

            var shoppingCartService = container.Resolve<ShoppingCartService>();
            
            return shoppingCartService;
        }
    }

}
