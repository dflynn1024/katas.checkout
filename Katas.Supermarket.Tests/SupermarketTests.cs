using System.Collections.Generic;
using Katas.Supermarket.Tests.Fixtures;
using Katas.Supermarket.Tests.SharedSteps.Givens;
using Katas.Supermarket.Tests.SharedSteps.Thens;
using Katas.Supermarket.Tests.SharedSteps.Whens;
using Xunit;

namespace Katas.Supermarket.Tests
{
    public class SuperMarketTests : IClassFixture<SystemUnderTestFixture<Supermarket>>
    {
        private readonly SystemUnderTestFixture<Supermarket> _fixture;

        public SuperMarketTests(SystemUnderTestFixture<Supermarket> fixture)
        {
            _fixture = fixture;
            _fixture.RegisterDependency<IBasketService>(new BasketService());
        }

        [Theory(DisplayName = "Thingy Tests")]
        [MemberData(nameof(TheoryDataForThingyScenarios))]
        public void SupermarketScenarios((string name, IList<Product> products, decimal expectedTotal) scenario)
        {
            Given.IHaveABasket(out var basket);
            Given.IHaveBoughtTheFollowingProducts(scenario.products, _fixture.SystemUnderTest, basket);
            When.ICheckoutMyBasket(_fixture.SystemUnderTest, basket, out var actualTotal);
            Then.TotalToPayIs(actualTotal, scenario.expectedTotal);
        }

        #region Theory Data

        public static TheoryData<(string name, IList<Product> products, decimal expectedTotal)> TheoryDataForThingyScenarios =>
            new TheoryData<(string name, IList<Product> products, decimal expectedTotal)>
            {
                (
                    name: "Scenario 1: ",
                    products: new List<Product>
                    {
                        new Product("Can of Beans", 0.65M),
                        new Product("Avocados", 1.25M),
                        new Product("Can of Soda", 2.05M)
                    },
                    expectedTotal: 3.95M
                )
           };

        #endregion

    }
}