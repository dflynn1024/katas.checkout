namespace Katas.Supermarket.Promotions
{
    public interface IPromotion
    {
        decimal CalculateDiscount(Product product, decimal quantity);
    }
}
