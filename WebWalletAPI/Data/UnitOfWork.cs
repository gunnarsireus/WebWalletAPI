using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebWalletAPI.Data
{
    public class UnitOfWork:IUnitOfWork
    {
	    private readonly WebWalletApiContext _context;

	    public UnitOfWork(WebWalletApiContext context)
	    {
		    _context = context;
			BankAccounts = new BankAccountRepository(_context);
			Transactions = new TransactionRepository(_context);
	    }

	    public void Dispose()
	    {
		   _context.Dispose();
	    }

	    public ITransactionRepository Transactions { get; private set; }
	    public IBankAccountRepository BankAccounts { get; private set; }
		public int Complete()
		{
			return _context.SaveChanges();
		}
    }
}
