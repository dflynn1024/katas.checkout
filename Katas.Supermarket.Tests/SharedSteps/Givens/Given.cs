using System.Collections.Generic;

namespace Katas.Supermarket.Tests.SharedSteps.Givens
{
    public static class Given
    {
        public static void SupermarketHasTheFollowingProducts(Supermarket supermarket, IList<Product> products)
        {
            foreach (var product in products)
            {
                supermarket.Products.Add(product);
            }
        }

        public static void CustomerHasTheFollowingItemsInTheirCart(IList<CartItem> items, out Cart cart)
        {
            cart = new Cart();

            foreach (var item in items)
            {
                cart.AddItem(item);
            }
        }
    }
}