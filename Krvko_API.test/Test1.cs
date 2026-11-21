
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Krvko_API.tst
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            // Arrange
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5044");

            // Act
            var response = await client.GetAsync("/api/test");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            string content = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(content.Contains("Krvko API is working!"));
            Assert.IsTrue(content.Contains("Success"));
        }
    }
}
