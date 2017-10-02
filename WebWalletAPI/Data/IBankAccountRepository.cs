using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWalletAPI.Models;

namespace WebWalletAPI.Data
{
    public interface IBankAccountRepository:IRepository<BankAccount>
    {
	    IEnumerable<BankAccount> GetBankAcocuntsWithBalanceGe(decimal balance, int pageIndex, int pageSize=10);
	}
}
