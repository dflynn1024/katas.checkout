using System.Collections.Generic;

namespace Katas.Supermarket
{
    public class Cart
    {
        public IList<CartItem> Items { get; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            Items.Add(item);
        }
    }
}
