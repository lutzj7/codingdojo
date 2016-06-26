using Autofac;

namespace ShoppingCartService.Tests
{
    internal class ShoppingCartServiceModule : Module
    {
        private const string ProductId = "#123";
        private const string ProductName = "Banana";
        const int bananaPriceCt = 34;

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ShoppingCartService>();

            builder.RegisterType<InventoryPersistency>()
                   .As<IInventoryPersistency>();

            builder.RegisterType<ShoppingCartPersistency>()
                   .As<IShoppingCartPersistency>();
        }
    }
}