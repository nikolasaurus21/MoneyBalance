using Microsoft.EntityFrameworkCore;
namespace MoneyBalance.Models
{
    public class MoneyBalanceContext : DbContext
    {
        public MoneyBalanceContext(DbContextOptions<MoneyBalanceContext> options) : base(options)
        {
        }

        public DbSet<MoneyBalance> MoneyBalances { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<MBHistory> MBHistorys { get; set; } = null!;
    }
}
