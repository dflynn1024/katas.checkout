using Katas.Supermarket.Tests.Fixtures;
using Katas.Supermarket.Tests.SharedSteps.Givens;
using Katas.Supermarket.Tests.SharedSteps.Thens;
using Katas.Supermarket.Tests.SharedSteps.Whens;
using System.Collections.Generic;
using Katas.Supermarket.Promotions;
using Xunit;

namespace Katas.Supermarket.Tests
{
    public class SuperMarketTests : IClassFixture<SystemUnderTestFixture<Supermarket>>
    {
        private readonly Supermarket _supermarket;
        private static readonly List<Product> Products = new List<Product>
        {
            new Product(1, "Can of Beans", 0.65M),
            new Product(2, "Avocados", 1.25M),
            new Product(3, "Can of Soda", 2.05M)
        };

        private const int Beans = 1;
        private const int Avocados = 2;
        private const int Soda = 3;

        public SuperMarketTests(SystemUnderTestFixture<Supermarket> fixture)
        {
            _supermarket = fixture.SystemUnderTest;
            _supermarket.Products.Clear();
            _supermarket.Promotions.Clear();
        }

        [Theory(DisplayName = "Checkout Scenarios")]
        [MemberData(nameof(TheoryDataForThingyScenarios))]
        public void SupermarketScenarios((string name, IList<Product> products, IDictionary<int, IPromotion> promotions, IList<CartItem> items, CheckoutSummary expectedCheckoutSummary) scenario)
        {
            Given.SupermarketHasTheFollowingProducts(_supermarket, scenario.products);
            Given.SupermarketHasTheFollowingPromotions(_supermarket, scenario.promotions);
            Given.CustomerHasTheFollowingItemsInTheirCart(scenario.items, out var cart);
            When.CustomerChecksOut(_supermarket, cart, out var checkoutSummary);
            Then.CheckoutSummaryIs(checkoutSummary, scenario.expectedCheckoutSummary);
        }

        #region Theory Data

        public static TheoryData<(string name, IList<Product> products, IDictionary<int, IPromotion> promotions, IList<CartItem> items, CheckoutSummary expectedCheckoutSummary)> TheoryDataForThingyScenarios =>
            new TheoryData<(string name, IList<Product> products, IDictionary<int, IPromotion> promotions, IList<CartItem> items, CheckoutSummary expectedCheckoutSummary)>
            {
                (
                    name: "Scenario 1: 1 of each item.",
                    products: Products,
                    promotions: null,
                    items: new List<CartItem>
                    {
                        new CartItem(Beans, 1),
                        new CartItem(Avocados, 1),
                        new CartItem(Soda, 1)
                    },
                    expectedCheckoutSummary: new CheckoutSummary(3.95M, 0.00M)
                ),
                (
                    name: "Scenario 2: Items with quantities greater than 1.",
                    products: Products,
                    promotions: null,
                    items: new List<CartItem>
                    {
                        new CartItem(Beans, 3),
                        new CartItem(Avocados, 5),
                        new CartItem(Soda, 2)
                    },
                    expectedCheckoutSummary: new CheckoutSummary(12.30M, 0.00M)
                ),
                (
                    name: "Scenario 3: Empty Cart",
                    products: Products,
                    promotions: null,
                    items: new List<CartItem>(),
                    expectedCheckoutSummary: new CheckoutSummary(0.00M, 0.00M)
                ),
                (
                    name: "Scenario 4: Avocados on 3 for 2",
                    products: Products,
                    promotions: new Dictionary<int, IPromotion>
                    {
                        {Avocados, new BuyXForY(3, 3.00M)}
                    },
                    items: new List<CartItem>
                    {
                        new CartItem(Avocados, 3.0M)
                    },
                    expectedCheckoutSummary: new CheckoutSummary(3.75M, 0.75M)
                ),
                (
                    name: "Scenario 5: Soda buy 1 get 1 free",
                    products: Products,
                    promotions: new Dictionary<int, IPromotion>
                    {
                        {Soda, new BuyXGetYFree(1, 1)}
                    },
                    items: new List<CartItem>
                    {
                        new CartItem(Soda, 2.0M)
                    },
                    expectedCheckoutSummary: new CheckoutSummary(4.10M, 2.05M)
                ),
                (
                    name: "Scenario 6: Avocados on 3 for 2, Soda buy 1 get 1 free",
                    products: Products,
                    promotions: new Dictionary<int, IPromotion>
                    {
                        {Avocados, new BuyXForY(3, 3)},
                        {Soda, new BuyXGetYFree(1, 1)}
                    },
                    items: new List<CartItem>
                    {
                        new CartItem(Avocados, 3.0M),
                        new CartItem(Soda, 2.0M)
                    },
                    expectedCheckoutSummary: new CheckoutSummary(7.85M, 2.80M)
                ),
                (
                    name: "Scenario 7: Avocados on 3 for 2, Soda buy 1 get 1 free, Beans not on special",
                    products: Products,
                    promotions: new Dictionary<int, IPromotion>
                    {
                        {Avocados, new BuyXForY(3, 3)},
                        {Soda, new BuyXGetYFree(1, 1)}
                    },
                    items: new List<CartItem>
                    {
                        new CartItem(Beans, 5.0M),
                        new CartItem(Avocados, 3.0M),
                        new CartItem(Soda, 2.0M)
                    },
                    expectedCheckoutSummary: new CheckoutSummary(11.10M, 2.80M)
                ),
                (
                    name: "Scenario 8: Avocados on 3 for 2, buy 6 so promo kicks in twice",
                    products: Products,
                    promotions: new Dictionary<int, IPromotion>
                    {
                        {Avocados, new BuyXForY(3, 3)}
                    },
                    items: new List<CartItem>
                    {
                        new CartItem(Avocados, 6.0M)
                    },
                    expectedCheckoutSummary: new CheckoutSummary(7.50M, 1.50M)
                ),
                (
                    name: "Scenario 9: Soda buy 1 get 1 free, buy 4 expect 2 free",
                    products: Products,
                    promotions: new Dictionary<int, IPromotion>
                    {
                        {Soda, new BuyXGetYFree(1, 1)}
                    },
                    items: new List<CartItem>
                    {
                        new CartItem(Soda, 4.0M)
                    },
                    expectedCheckoutSummary: new CheckoutSummary(8.20M, 4.10M)
                )
           };

        #endregion

    }
}
