namespace Katas.Supermarket
{
    public class CartItem
    {
        public int ProductId { get; }
        public int Quantity { get; }

        public CartItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
