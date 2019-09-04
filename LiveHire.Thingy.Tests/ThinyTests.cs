using LiveHire.Thingy.Tests.Fixtures;
using Xunit;

namespace LiveHire.Thingy.Tests
{
    public class ThingyTests : IClassFixture<SystemUnderTestFixture<Thingy>>
    {
        private readonly SystemUnderTestFixture<Thingy> _fixture;

        public ThingyTests(SystemUnderTestFixture<Thingy> fixture)
        {
            _fixture = fixture;
        }

        [Theory(DisplayName = "Thingy Tests")]
        [MemberData(nameof(TheoryDataForThingyScenarios))]
        public void ThingyScenarios((string name, bool expectation) scenario)
        {

        }

        #region Theory Data

        public static TheoryData<(string name, bool expectation)> TheoryDataForThingyScenarios =>
            new TheoryData<(string name, bool expectation)>
            {
                (
                    name: "Scenario 1: ", 
                    expectation: true
                )
           };

        #endregion

    }
}
