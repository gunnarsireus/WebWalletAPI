using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebWalletAPI.Models;

namespace WebWalletAPI.Data
{
	public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
	{
		public BankAccountRepository(WebWalletApiContext context) : base(context)
		{
		}

		public WebWalletApiContext WebWalletApiContext => Context as WebWalletApiContext;

		public IEnumerable<BankAccount> GetBankAcocuntsWithBalanceGe(decimal balance, int pageIndex, int pageSize = 10)
		{
			return WebWalletApiContext.BankAccount
				.Include(b => b.Comment)
				.OrderBy(b => b.Balance)
				.Skip((pageIndex - 1) * pageSize)
				.Take(pageSize)
				.ToList();
		}
	}
}
