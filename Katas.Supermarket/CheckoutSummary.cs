namespace Katas.Supermarket
{
    public class CheckoutSummary
    {
        public decimal Total { get; }
        public decimal Discount { get; }
        public decimal TotalAfterDiscount => Discount > Total ? 0.00M : Total - Discount;

        public CheckoutSummary(decimal total, decimal discount)
        {
            Total = total;
            Discount = discount;
        }
    }
}
