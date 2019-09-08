using System.Collections.Generic;

namespace Katas.Supermarket
{
    public interface IBasketService
    {
        void AddProductsToBasket(Basket basket, IList<Product> products);
    }
}
