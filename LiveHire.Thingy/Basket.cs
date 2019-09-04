using System.Collections.Generic;

namespace LiveHire.Thingy
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
