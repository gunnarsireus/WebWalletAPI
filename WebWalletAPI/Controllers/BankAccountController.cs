using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebWalletAPI;
using WebWalletAPI.Models;

namespace WebWalletAPIAPI.Controllers
{
    [Route("api/[controller]")]
    public class BankAccountController : Controller
    {
        // GET api/bankaccount
        [HttpGet]
        public IEnumerable<BankAccount> GetBankAccounts()
        {
            var dataAccess = new WebWalletAPI.Data.DataAccess();
            return dataAccess.GetBankAccounts();
        }

        // GET api/bankaccount/5
        [HttpGet("{id}")]
        public BankAccount GetBankAccount(string id)
        {
            var dataAccess = new WebWalletAPI.Data.DataAccess();
            return dataAccess.GetBankAccount(new Guid(id));
        }

        // POST api/bankaccount
        [HttpPost]
        public void AddBankAccount([FromBody]BankAccount bankAccount)
        {
            var dataAccess = new WebWalletAPI.Data.DataAccess();
            dataAccess.AddBankAccount(bankAccount);
        }

        // PUT api/bankaccount/5
        [HttpPut("{id}")]
        public void UpdateBankAccount([FromBody]BankAccount bankAccount)
        {
            var dataAccess = new WebWalletAPI.Data.DataAccess();
            dataAccess.UpdateBankAccount(bankAccount);
        }

        // DELETE api/bankaccount/5
        [HttpDelete("{id}")]
        public void DeleteBankAccount(string id)
        {
            var dataAccess = new WebWalletAPI.Data.DataAccess();
            dataAccess.DeleteBankAccount(new Guid(id));
        }
    }
}
