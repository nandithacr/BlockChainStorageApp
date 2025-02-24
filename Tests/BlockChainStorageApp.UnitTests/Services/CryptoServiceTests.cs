using Moq;
using BlockChainStorageApp.Core.Interfaces;
using BlockChainStorageApp.Core.Services;
using BlockChainStorageApp.Domain.Entities;

namespace BlockChainStorageApp.UnitTests.Services
{
    [TestFixture]
    public class CryptoServiceTests
    {
        private Mock<ICryptoRepository> _cryptoRepositoryMock;
        private Mock<IBlockCypherClient> _blockCypherClientMock;
        private CryptoService _cryptoService;

        [SetUp]
        public void Setup()
        {
            _cryptoRepositoryMock = new Mock<ICryptoRepository>();
            _blockCypherClientMock = new Mock<IBlockCypherClient>();
            _cryptoService = new CryptoService(_cryptoRepositoryMock.Object, _blockCypherClientMock.Object);
        }

        [Test]
        public async Task SyncLatestCryptoData_ShouldCall_FetchAndStoreCryptoDataAsync()
        {
            // Act
            await _cryptoService.SyncLatestCryptoData();

            // Assert
            _blockCypherClientMock.Verify(client => client.FetchAndStoreCryptoDataAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllCryptoDataAsync_ShouldReturnData()
        {
            // Arrange
            var testData = new List<CryptoData>
            {
                new CryptoData { Symbol = "BTC", Name = "BTC.main", Height = 100 },
                new CryptoData { Symbol = "ETH", Name = "ETH.main", Height = 200 }
            };

            _cryptoRepositoryMock.Setup(repo => repo.GetAllCryptoDataAsync())
                .ReturnsAsync(testData);

            // Act
            var result = await _cryptoService.GetAllCryptoDataAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetCryptoHistoryBySymbolAsync_ShouldReturnFilteredData()
        {
            // Arrange
            var testData = new List<CryptoData>
            {
                new CryptoData { Symbol = "BTC", Name = "BTC.main", Height = 100 },
                new CryptoData { Symbol = "BTC", Name = "BTC.main", Height = 101 }
            };

            _cryptoRepositoryMock.Setup(repo => repo.GetCryptoHistoryBySymbolAsync("BTC"))
                .ReturnsAsync(testData);

            // Act
            var result = await _cryptoService.GetCryptoHistoryBySymbolAsync("BTC");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(r => r.Symbol == "BTC"));
        }


    }
}
