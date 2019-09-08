using Katas.Supermarket.Tests.Fixtures;
using Katas.Supermarket.Tests.SharedSteps.Givens;
using Katas.Supermarket.Tests.SharedSteps.Thens;
using Katas.Supermarket.Tests.SharedSteps.Whens;
using System.Collections.Generic;
using Xunit;

namespace Katas.Supermarket.Tests
{
    public class SuperMarketTests : IClassFixture<SystemUnderTestFixture<Supermarket>>
    {
        private readonly Supermarket _supermarket;

        public SuperMarketTests(SystemUnderTestFixture<Supermarket> fixture)
        {
            _supermarket = fixture.SystemUnderTest;
            _supermarket.Products.Clear();
        }

        [Theory(DisplayName = "Checkout Scenarios")]
        [MemberData(nameof(TheoryDataForThingyScenarios))]
        public void SupermarketScenarios((string name, IList<Product> products, IList<CartItem> items, decimal expectedTotal) scenario)
        {
            Given.SupermarketHasTheFollowingProducts(_supermarket, scenario.products);
            Given.CustomerHasTheFollowingItemsInTheirCart(scenario.items, out var cart);
            When.CustomerChecksOut(_supermarket, cart, out var total);
            Then.TotalToPayIs(total, scenario.expectedTotal);
        }

        #region Theory Data

        public static TheoryData<(string name, IList<Product> products, IList<CartItem> items, decimal expectedTotal)> TheoryDataForThingyScenarios =>
            new TheoryData<(string name, IList<Product> products, IList<CartItem> items, decimal expectedTotal)>
            {
                (
                    name: "Scenario 1: 1 of each item.",
                    products: new List<Product>
                    {
                        new Product(1,"Can of Beans", 0.65M),
                        new Product(2,"Avocados", 1.25M),
                        new Product(3,"Can of Soda", 2.05M)
                    },
                    items: new List<CartItem>
                    {
                        new CartItem(1, 1),
                        new CartItem(2, 1),
                        new CartItem(3, 1)
                    },
                    expectedTotal: 3.95M
                ),
                (
                    name: "Scenario 2: Items with quantities greater than 1.",
                    products: new List<Product>
                    {
                        new Product(1,"Can of Beans", 0.65M),
                        new Product(2,"Avocados", 1.25M),
                        new Product(3,"Can of Soda", 2.05M)
                    },
                    items: new List<CartItem>
                    {
                        new CartItem(1, 3),
                        new CartItem(2, 5),
                        new CartItem(3, 2)
                    },
                    expectedTotal: 12.30M
                ),
                (
                    name: "Scenario 3: Empty Cart",
                    products: new List<Product>
                    {
                        new Product(1,"Can of Beans", 0.65M),
                        new Product(2,"Avocados", 1.25M),
                        new Product(3,"Can of Soda", 2.05M)
                    },
                    items: new List<CartItem>(),
                    expectedTotal: 0.00M
                )
           };

        #endregion

    }
}
