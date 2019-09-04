using System.Collections.Generic;

namespace LiveHire.Thingy.Tests.SharedSteps.Givens
{
    public static class Given
    {
        public static void IHaveABasket(out Basket basket)
        {
            basket = new Basket();
        }

        public static void IHaveBoughtTheFollowingProducts(IList<Product> products, Supermarket supermarket, Basket basket )
        {
            supermarket.AddProductsToBasket(products, basket);
        }
    }
}