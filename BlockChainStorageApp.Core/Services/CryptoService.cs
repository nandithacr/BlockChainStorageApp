using BlockChainStorageApp.Core.Interfaces;
using BlockChainStorageApp.Domain.Entities;

namespace BlockChainStorageApp.Core.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly ICryptoRepository _cryptoRepository;
        private readonly IBlockCypherClient _blockCypherClient;

        public CryptoService(ICryptoRepository cryptoRepository, IBlockCypherClient blockCypherClient)
        {
            _cryptoRepository = cryptoRepository;
            _blockCypherClient = blockCypherClient;
        }

        public async Task SyncLatestCryptoData()
        {
            await _blockCypherClient.FetchAndStoreCryptoDataAsync();
        }

        public async Task<IEnumerable<CryptoData>> GetAllCryptoDataAsync()
        {
            return await _cryptoRepository.GetAllCryptoDataAsync();
        }

        public async Task<IEnumerable<CryptoData>> GetCryptoHistoryBySymbolAsync(string symbol)
        {
            return await _cryptoRepository.GetCryptoHistoryBySymbolAsync(symbol);
        }
    }
}
