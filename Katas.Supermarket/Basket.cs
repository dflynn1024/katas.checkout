using System.Collections.Generic;

namespace Katas.Supermarket
{
    public class Basket
    {
        public IList<Product> Products { get; }

        public Basket()
        {
            Products = new List<Product>();
        }
    }
}
