using System;
using Autofac.Extras.Moq;
using Moq;

namespace Katas.Supermarket.Tests.Fixtures
{
    /// <summary>
    /// Use this fixture to setup your SuT (System Under Test)
    /// </summary>
    /// <remarks>
    /// All SuT dependencies will be auto-mocked (loose). Note: strict, will throw an exception if
    /// an unexpected (not configured /set up) method was called.
    /// </remarks>
    /// <typeparam name="TSuT">Any class that represents your SuT</typeparam>
    public class SystemUnderTestFixture<TSuT> : IDisposable
        where TSuT : class
    {
        private readonly AutoMock _mock;
        private TSuT _systemUnderTest;

        public TSuT SystemUnderTest => _systemUnderTest ?? (_systemUnderTest = _mock.Create<TSuT>());

        public SystemUnderTestFixture()
        {
            _mock = AutoMock.GetLoose();
        }

        /// <summary>
        /// Register any SuT dependencies that you don't want auto-mocked.
        /// </summary>
        public void RegisterDependency<TDependency>(TDependency dependency)
            where TDependency : class
        {
            _mock.Provide(dependency);
        }
        
        /// <summary>
        /// Get a mocked SuT dependency so that you can setup and verify in unit tests.
        /// </summary>
        public Mock<TDependency> GetMockedDependency<TDependency>()
            where TDependency : class
        {
            return _mock.Mock<TDependency>();
        }

        public void Dispose()
        {
            _mock.Dispose();
        }
    }
}
