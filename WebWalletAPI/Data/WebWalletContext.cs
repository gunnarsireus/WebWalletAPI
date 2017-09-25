using Microsoft.EntityFrameworkCore;
using WebWalletAPI.Models;

namespace WebWalletAPI.Data
{
    public class WebWalletAPIContext : DbContext
    {
        public WebWalletAPIContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<BankAccount> BankAccount { get; set; }

        public DbSet<Transaction> Transaction { get; set; }
    }
}