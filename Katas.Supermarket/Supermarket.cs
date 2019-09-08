using System.Collections.Generic;
using System.Linq;

namespace Katas.Supermarket
{
    public class Supermarket
    {
        public IList<Product> Products { get; }

        public Supermarket()
        {
            Products = new List<Product>();
        }

        public decimal Checkout(Cart cart)
        {
            return cart.Items
                .Join(Products, i => i.ProductId, p => p.Id, (item, product) => item.Quantity * product.Price)
                .Sum();
        }
    }
}
