using System.Collections.Generic;

namespace Katas.Supermarket
{
    public class BasketService : IBasketService
    {
        public void AddProductsToBasket(Basket basket, IList<Product> products)
        {
            foreach (var product in products)
            {
                basket.Products.Add(product);
            }
        }
    }
}
