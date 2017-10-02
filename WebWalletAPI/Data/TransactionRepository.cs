using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebWalletAPI.Models;

namespace WebWalletAPI.Data
{
	public class TransactionRepository : Repository<Transaction>, ITransactionRepository
	{
		public TransactionRepository(DbContext context) : base(context)
		{
		}

		public WebWalletApiContext WebWalletApiContext => Context as WebWalletApiContext;
		public IEnumerable<Transaction> GetTransactionsSince(DateTime date)
		{
			return WebWalletApiContext.Transaction.Where(t => DateTime.Parse(t.CreationTime) >= date).ToList();
		}
	}
}
