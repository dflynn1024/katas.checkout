using System.Collections.Generic;
using Katas.Supermarket.Promotions;

namespace Katas.Supermarket.Tests.SharedSteps.Givens
{
    public static class Given
    {
        public static void SupermarketHasTheFollowingPromotions(Supermarket supermarket, IDictionary<int, IPromotion> promotions)
        {
            if (promotions == null)
                return;

            foreach (var promotion in promotions)
            {
                supermarket.Promotions.Add(promotion);
            }
        }

        public static void SupermarketHasTheFollowingProducts(Supermarket supermarket, IList<Product> products)
        {
            if (products == null)
                return;

            foreach (var product in products)
            {
                supermarket.Products.Add(product);
            }
        }

        public static void CustomerHasTheFollowingItemsInTheirCart(IList<CartItem> items, out Cart cart)
        {
            cart = new Cart();

            if (items == null)
                return;

            foreach (var item in items)
            {
                cart.AddItem(item);
            }
        }
    }
}