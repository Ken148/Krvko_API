using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Krvko_API.tst
{
    [TestClass]
    public class Test1
    {
        private static WebApplicationFactory<Program> _factory = null!;
        private static HttpClient _client = null!;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            var response = await _client.GetAsync("/WeatherForecast");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}