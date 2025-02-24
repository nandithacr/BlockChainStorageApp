using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BlockChainStorageApp.FunctionalTests
{
    [TestFixture]
    public class ApiFunctionalTests
    {
        private HttpClient _client;
        private WebApplicationFactory<Program> _factory;

        public ApiFunctionalTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task SyncLatestCryptoData_ReturnsSuccess()
        {
            var response = await _client.PostAsync("/api/crypto/sync", null);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.That(content, Does.Contain("Data synced successfully."));
        }

        [Test]
        public async Task GetAllCryptoData_ReturnsValidResponse()
        {
            var response = await _client.GetAsync("/api/crypto/all");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(content);
            Assert.That(content, Does.Contain("BTC.main").Or.Contain("ETH.main"));
        }

        [Test]
        public async Task GetCryptoHistoryBySymbol_ReturnsValidResponse()
        {
            var response = await _client.GetAsync("/api/crypto/history/BTC");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(content);
            Assert.That(content, Does.Contain("BTC"));
        }

        [Test]
        public async Task GetCryptoHistoryBySymbol_InvalidSymbol_ReturnsEmpty()
        {
            var response = await _client.GetAsync("/api/crypto/history/INVALID");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(content);
            Assert.That(content, Does.Contain("[]")); // Expecting an empty array
        }

        [Test]
        public async Task SyncCryptoData_PersistsToDatabase()
        {
            await _client.PostAsync("/api/crypto/sync", null);
            var response = await _client.GetAsync("/api/crypto/all");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(content);
            Assert.That(content, Does.Contain("BTC.main").Or.Contain("ETH.main"));
        }

        [Test]
        public async Task CryptoEndpoints_ReturnValidJson()
        {
            var response = await _client.GetAsync("/api/crypto/all");
            response.EnsureSuccessStatusCode();

            var contentType = response.Content.Headers.ContentType.MediaType;
            Assert.That(contentType, Is.EqualTo("application/json"));
        }
    }
}