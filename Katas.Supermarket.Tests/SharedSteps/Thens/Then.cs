using FluentAssertions;

namespace Katas.Supermarket.Tests.SharedSteps.Thens
{
    public static class Then
    {
        public static void CheckoutSummaryIs(CheckoutSummary checkoutSummary, CheckoutSummary expectedCheckoutSummary)
        {
            checkoutSummary.Should().BeEquivalentTo(expectedCheckoutSummary);
        }
    }
}