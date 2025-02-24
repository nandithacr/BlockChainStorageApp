using BlockChainStorageApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlockChainStorageApp.Presentation.Controllers

{
    [ApiController]
    [Route("api/crypto")]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;
        private readonly ILogger<CryptoController> _logger;

        public CryptoController(ICryptoService cryptoService, ILogger<CryptoController> logger)
        {
            _cryptoService = cryptoService;
            _logger = logger;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncLatestCryptoData()
        {
            try
            {
                await _cryptoService.SyncLatestCryptoData();
                return Ok(new { message = "Data synced successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error syncing latest crypto data: {ex.Message}");
                return StatusCode(500, new { error = "An error occurred while syncing crypto data." });
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCryptoData()
        {
            try
            {
                var cryptoData = await _cryptoService.GetAllCryptoDataAsync();
                return Ok(cryptoData);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting all crypto data: {ex.Message}");
                return StatusCode(500, new { error = "An error occurred while getting all crypto data." });
            }
        }

        [HttpGet("history/{symbol}")]
        public async Task<IActionResult> GetCryptoHistory(string symbol)
        {
            try
            {
                var cryptoHistory = await _cryptoService.GetCryptoHistoryBySymbolAsync(symbol);
                return Ok(cryptoHistory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when getting crypto data history: {ex.Message}");
                return StatusCode(500, new { error = "An error occurred while getting crypto data history." });
            }
        }
    }
}