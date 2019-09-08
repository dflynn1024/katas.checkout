namespace Katas.Supermarket.Tests.SharedSteps.Whens
{
    public static class When
    {
        public static void CustomerChecksOut(Supermarket supermarket, Cart cart, out CheckoutSummary checkoutSummary)
        {
            checkoutSummary = supermarket.Checkout(cart);
        }
    }
}
