using System.Text.Json;
using BlockChainStorageApp.Core.Interfaces;
using BlockChainStorageApp.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BlockChainStorageApp.External.Services
{
    public class BlockCypherClient : IBlockCypherClient
    {
        private readonly HttpClient _httpClient;
        private readonly ICryptoRepository _cryptoRepository;
        private readonly ILogger<BlockCypherClient> _logger;

        private readonly string[] _endpoints = {
            "https://api.blockcypher.com/v1/eth/main",
            "https://api.blockcypher.com/v1/dash/main",
            "https://api.blockcypher.com/v1/btc/main",
            "https://api.blockcypher.com/v1/btc/test3",
            "https://api.blockcypher.com/v1/ltc/main"
        };

        public BlockCypherClient(HttpClient httpClient, ICryptoRepository cryptoRepository, ILogger<BlockCypherClient> logger)
        {
            _httpClient = httpClient;
            _cryptoRepository = cryptoRepository;
            _logger = logger;
        }
        public async Task FetchAndStoreCryptoDataAsync()
        {
            foreach (var endpoint in _endpoints)
            {
                try
                {
                    var response = await _httpClient.GetAsync(endpoint);
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var cryptoData = JsonSerializer.Deserialize<CryptoData>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (cryptoData != null)
                    {
                        var data = new CryptoData
                        {
                            Symbol = cryptoData.Name.Split('.')[0],
                            Name = cryptoData.Name,
                            Height = cryptoData.Height,
                            Hash = cryptoData.Hash,
                            Time = cryptoData.Time,
                            Latest_Url = cryptoData.Latest_Url,
                            Previous_Hash = cryptoData.Previous_Hash,
                            Previous_Url = cryptoData.Previous_Url,
                            Peer_Count = cryptoData.Peer_Count,
                            Unconfirmed_Count = cryptoData.Unconfirmed_Count,
                            High_Fee_Per_Kb = cryptoData.High_Fee_Per_Kb,
                            Medium_Fee_Per_Kb = cryptoData.Medium_Fee_Per_Kb,
                            Low_Fee_Per_Kb = cryptoData.Low_Fee_Per_Kb,
                            Last_Fork_Height = cryptoData.Last_Fork_Height,
                            Last_Fork_Hash = cryptoData.Last_Fork_Hash,
                            CreatedAt = DateTime.UtcNow
                        };

                        await _cryptoRepository.AddCryptoDataAsync(data);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error fetching data from {endpoint}: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
