using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebWalletAPI.Models;

namespace WebWalletAPI.Data
{
    public class DataAccess
    {
        readonly DbContextOptionsBuilder<WebWalletAPIContext> _optionsBuilder = new DbContextOptionsBuilder<WebWalletAPIContext>();
        public DataAccess()
        {
            _optionsBuilder.UseSqlite("DataSource=App_Data/WebWallet.db");
        }
        public ICollection<BankAccount> GetBankAccounts()
        {
            using ( var context = new WebWalletAPIContext(_optionsBuilder.Options))
            {
                return context.BankAccount.ToList();
            }
        }

        public BankAccount GetBankAccount(Guid id)
        {

            using (var context = new WebWalletAPIContext(_optionsBuilder.Options))
            {
                return context.BankAccount.SingleOrDefault(o=>o.Id==id);
            }
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            using (var context = new WebWalletAPIContext(_optionsBuilder.Options))
            {
                context.BankAccount.Add(bankAccount);
                context.SaveChanges();
            }
        }

        public void DeleteBankAccount(Guid id)
        {
            using (var context = new WebWalletAPIContext(_optionsBuilder.Options))
            {
                var bankAccount = GetBankAccount(id);
                context.BankAccount.Remove(bankAccount);
                context.SaveChanges();
            }
        }

        public void UpdateBankAccount(BankAccount bankAccount)
        {
            using (var context = new WebWalletAPIContext(_optionsBuilder.Options))
            {
                context.BankAccount.Update(bankAccount);
                context.SaveChanges();
            }
        }

        public ICollection<Transaction> GetTransactions()
        {
            using (var context = new WebWalletAPIContext(_optionsBuilder.Options))
            {
                return context.Transaction.ToList();
            }
        }

        public Transaction GetTransaction(Guid id)
        {
            using (var context = new WebWalletAPIContext(_optionsBuilder.Options))
            {
                return context.Transaction.SingleOrDefault(o => o.Id == id);
            }
        }

        public void AddTransaction(Transaction bankAccount)
        {
            using (var context = new WebWalletAPIContext(_optionsBuilder.Options))
            {
                context.Transaction.Add(bankAccount);
                context.SaveChanges();
            }
        }

        public void DeleteTransaction(Guid id)
        {
            using (var context = new WebWalletAPIContext(_optionsBuilder.Options))
            {
                var transaction = GetTransaction(id);
                context.Transaction.Remove(transaction);
                context.SaveChanges();
            }
        }

        public void UpdateTransaction(Transaction bankAccount)
        {
            using (var context = new WebWalletAPIContext(_optionsBuilder.Options))
            {
                context.Transaction.Update(bankAccount);
                context.SaveChanges();
            }
        }
    }
}
