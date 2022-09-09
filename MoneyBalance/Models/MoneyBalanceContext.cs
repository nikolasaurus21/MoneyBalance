using Microsoft.EntityFrameworkCore;
namespace MoneyBalance.Models
{
    public class MoneyBalanceContext : DbContext
    {
        public MoneyBalanceContext(DbContextOptions<MoneyBalanceContext> options) : base(options)
        {
        }

        public DbSet<Money_Balance> MoneyBalances { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<MBHistory> MBHistorys { get; set; } = null!;
    }
}
