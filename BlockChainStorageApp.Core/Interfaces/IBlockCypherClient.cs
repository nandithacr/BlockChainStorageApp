namespace BlockChainStorageApp.Core.Interfaces
{
    public interface IBlockCypherClient
    {
        Task FetchAndStoreCryptoDataAsync();
    }
}
