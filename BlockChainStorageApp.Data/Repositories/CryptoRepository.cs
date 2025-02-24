using BlockChainStorageApp.Core.Interfaces;
using BlockChainStorageApp.Data.Data;
using BlockChainStorageApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlockChainStorageApp.Data.Repositories
{
    public class CryptoRepository : ICryptoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CryptoRepository> _logger;

        public CryptoRepository(ApplicationDbContext context, ILogger<CryptoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<CryptoData>> GetAllCryptoDataAsync()
        {
            try
            {
                return await _context.CryptoData
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching all crypto data from the database: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<CryptoData>> GetCryptoHistoryBySymbolAsync(string symbol)
        {
            try
            {
                return await _context.CryptoData
                .Where(c => c.Name.ToLower().StartsWith(symbol.ToLower()))
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching crypto history data from the database: {ex.Message}");
                throw;
            }
        }

        public async Task AddCryptoDataAsync(CryptoData crypto)
        {
            try
            {
                await _context.CryptoData.AddAsync(crypto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving crypto data to the database: {ex.Message}");
                throw;
            }
        }
    }
}
