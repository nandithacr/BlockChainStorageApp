using BlockChainStorageApp.Domain.Entities;

namespace BlockChainStorageApp.Core.Interfaces
{
    public interface ICryptoService
    {
        Task SyncLatestCryptoData();
        Task<IEnumerable<CryptoData>> GetAllCryptoDataAsync();
        Task<IEnumerable<CryptoData>> GetCryptoHistoryBySymbolAsync(string symbol);
    }
}