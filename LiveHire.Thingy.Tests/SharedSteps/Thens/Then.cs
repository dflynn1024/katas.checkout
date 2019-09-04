using FluentAssertions;

namespace LiveHire.Thingy.Tests.SharedSteps.Thens
{
    public static class Then
    {
        public static void TotalToPayIs(decimal actualTotal, decimal expectedTotal)
        {
            actualTotal.Should().Be(expectedTotal);
        }
    }
}