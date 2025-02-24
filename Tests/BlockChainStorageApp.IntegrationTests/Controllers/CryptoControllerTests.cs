using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BlockChainStorageApp.IntegrationTests.Controllers
{
    [TestFixture]
    public class CryptoControllerTests
    {
        private HttpClient _client;
        private WebApplicationFactory<Program> _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task GetAllCryptoData_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/api/crypto/all");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(content);
        }

        [Test]
        public async Task GetCryptoHistory_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/api/crypto/history/BTC");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(content);
        }

    }
}
