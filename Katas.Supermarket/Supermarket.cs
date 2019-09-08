using System.Collections.Generic;
using System.Linq;
using Katas.Supermarket.Promotions;

namespace Katas.Supermarket
{
    public class Supermarket
    {
        public IList<Product> Products { get; }
        public IDictionary<int, IPromotion> Promotions { get; }

        public Supermarket()
        {
            Products = new List<Product>();
            Promotions = new Dictionary<int, IPromotion>();
        }

        public CheckoutSummary Checkout(Cart cart)
        {
            var total = CalculateTotal(cart);
            var discount = CalculateTotalDiscount(cart);

            return new CheckoutSummary(total, discount);
        }

        #region private helpers

        private decimal CalculateTotal(Cart cart)
        {
            return cart.Items
                .Join(Products, i => i.ProductId, p => p.Id, (item, product) => item.Quantity * product.Price)
                .Sum();
        }

        private decimal CalculateTotalDiscount(Cart cart)
        {
            return cart.Items
                .Join(Products, i => i.ProductId, p => p.Id, (item, product) => CalculateItemDiscount(product, item))
                .Sum();
        }

        private decimal CalculateItemDiscount(Product product, CartItem item)
        {
            return Promotions.Keys.Contains(product.Id) 
                ? Promotions[product.Id].CalculateDiscount(product, item.Quantity) 
                : 0;
        }

        #endregion
    }
}
