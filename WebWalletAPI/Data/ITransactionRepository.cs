using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWalletAPI.Models;

namespace WebWalletAPI.Data
{
    public interface ITransactionRepository:IRepository<Transaction>
    {
	    IEnumerable<Transaction> GetTransactionsSince(DateTime date);
    }
}
