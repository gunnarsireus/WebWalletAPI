using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWalletAPI.Data
{
    interface IUnitOfWork: IDisposable
    {
	    ITransactionRepository Transactions { get; }
	    IBankAccountRepository BankAccounts { get; }
	    int Complete();
    }
}
