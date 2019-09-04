using System.Collections.Generic;

namespace LiveHire.Thingy
{
    public interface IBasketService
    {
        void AddProductsToBasket(Basket basket, IList<Product> products);
    }
}
