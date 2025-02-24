using Microsoft.EntityFrameworkCore;
using BlockChainStorageApp.Domain.Entities;

namespace BlockChainStorageApp.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CryptoData> CryptoData { get; set; }

    }
}
