using BlockChainStorageApp.Domain.Entities;

namespace BlockChainStorageApp.Core.Interfaces
{
    public interface ICryptoRepository
    {

        Task<IEnumerable<CryptoData>> GetAllCryptoDataAsync();
        Task<IEnumerable<CryptoData>> GetCryptoHistoryBySymbolAsync(string symbol);
        Task AddCryptoDataAsync(CryptoData crypto);
    }
}
