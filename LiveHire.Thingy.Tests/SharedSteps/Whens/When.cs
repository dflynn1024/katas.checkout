namespace LiveHire.Thingy.Tests.SharedSteps.Whens
{
    public static class When
    {
        public static void ICheckoutMyBasket(Supermarket supermarket, Basket basket, out decimal totalPrice)
        {
            totalPrice = supermarket.Checkout(basket);
        }
    }
}
