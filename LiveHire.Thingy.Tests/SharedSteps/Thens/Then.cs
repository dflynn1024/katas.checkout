using FluentAssertions;

namespace Katas.Supermarket.Tests.SharedSteps.Thens
{
    public static class Then
    {
        public static void TotalToPayIs(decimal actualTotal, decimal expectedTotal)
        {
            actualTotal.Should().Be(expectedTotal);
        }
    }
}