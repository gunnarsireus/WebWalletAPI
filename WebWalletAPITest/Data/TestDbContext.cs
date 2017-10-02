using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebWalletAPI.Data;
using WebWalletAPI.Models;


namespace WebWalletAPITest.Data
{
    public static class TestDbContext
    {
	    public static WebWalletApiContext GetContextWithData()
	    {
		    var options = new DbContextOptionsBuilder<WebWalletApiContext>()
			    .UseSqlite("DataSource=:memory:")
			    .Options;
		    var context = new WebWalletApiContext(options);
		    var bankId = Guid.NewGuid();
		    var transactionId = Guid.NewGuid();
			var bankAccount = new BankAccount() { Id = bankId, Comment = "Kapitalkonto", Balance = "100", CreationTime = "", InterestRate = "", OwnerId = Guid.NewGuid(), Transactions = new List<Transaction>()};
		    var transaction = new Transaction { Id = transactionId, BankAccountId = bankId, Comment = "Insättning", Deposit = "100", CreationTime = "", Withdraw = ""};
		    context.BankAccount.Add(bankAccount);
			context.Transaction.Add(transaction);
		    try
		    {
			    context.SaveChanges();
		    }
		    catch (Exception ex)
		    {
			    var a = ex;
		    }
		    return context;
	    }
	}
}
