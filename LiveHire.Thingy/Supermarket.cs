using System.Collections.Generic;
using System.Linq;

namespace Katas.Supermarket
{

    public class Supermarket
    {
        private readonly IBasketService _basketService;

        public Supermarket(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public void AddProductsToBasket(IList<Product> product, Basket basket)
        {
            _basketService.AddProductsToBasket(basket, product);
        }

        public decimal Checkout(Basket basket)
        {
            return basket.Products.Sum(p => p.Price);
        }
    }
}
