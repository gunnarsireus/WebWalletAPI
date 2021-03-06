using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using WebWalletAPI.Controllers;
using WebWalletAPI.Data;
using WebWalletAPI.Models;
using Xunit;

namespace WebWalletAPITest
{
	public class UnitTest1
	{
		[Fact(DisplayName = "Index visar ett bankkonto med en transaction")]
		public void Test1()
		{
			// In-memory database only exists while the connection is open
			var connection = new SqliteConnection("DataSource=:memory:");
			connection.Open();
			try
			{
				var options = new DbContextOptionsBuilder<WebWalletApiContext>()
					.UseSqlite(connection)
					.Options;

				// Create the schema in the database
				using (var context = new WebWalletApiContext(options))
				{
					context.Database.EnsureCreated();
				}
				using (var context = new WebWalletApiContext(options))
				{
					var bankId = Guid.NewGuid();
					var transactionId = Guid.NewGuid();
					var bankAccount = new BankAccount() { Id = bankId, Comment = "Kapitalkonto", Balance = "100", CreationTime = "", InterestRate = "", OwnerId = Guid.NewGuid(), Transactions = new List<Transaction>() };
					var transaction = new Transaction { Id = transactionId, BankAccountId = bankId, Comment = "Insättning", Deposit = "100", CreationTime = "", Withdraw = "" };
					context.BankAccount.Add(bankAccount);
					context.Transaction.Add(transaction);
					context.SaveChanges();
				}

				using (var context = new WebWalletApiContext(options))
				{
					var bc = new BankAccountController(context);
					var result = bc.GetBankAccounts();
					Assert.NotNull(result);
					Assert.Equal(result.Count(), 1);
				}
				using (var context = new WebWalletApiContext(options))
				{
					var tc = new TransactionController(context);
					var result = tc.Get();
					Assert.NotNull(result);
					Assert.Equal(result.Count(), 1);
				}
			}
			finally
			{
				connection.Close();
			}
		}
	}
}
