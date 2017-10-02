using Microsoft.EntityFrameworkCore;
using WebWalletAPI.Models;

namespace WebWalletAPI.Data
{
    public class WebWalletApiContext : DbContext
    {
        public WebWalletApiContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<BankAccount> BankAccount { get; set; }

        public DbSet<Transaction> Transaction { get; set; }
    }
}