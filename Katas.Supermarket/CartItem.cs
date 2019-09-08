namespace Katas.Supermarket
{
    public class CartItem
    {
        public int ProductId { get; }
        public decimal Quantity { get; }

        public CartItem(int productId, decimal quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
