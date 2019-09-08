using System;

namespace Katas.Supermarket.Promotions
{
    /// <summary>
    /// Buy X amount of product and get for Y items for free. E.g. 2 Avocados get 1 free.
    /// </summary>
    public class BuyXGetYFree : IPromotion
    {
        private readonly decimal _x;
        private readonly decimal _y;

        public BuyXGetYFree(decimal x, decimal y)
        {
            _x = x;
            _y = y;
        }

        public decimal CalculateDiscount(Product product, decimal quantity)
        {
            return _x == 0 
                ? 0 
                : Math.Floor(quantity / (_x + 1)) * (product.Price * _y);
        }
    }
}