using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebWalletAPI.Data;
using WebWalletAPI.Models;

namespace WebWalletAPI.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        // GET api/transaction
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            var dataAccess = new DataAccess();
            return dataAccess.GetTransactions();
        }

        // GET api/transaction/5
        [HttpGet("{id}")]
        public Transaction Get(string id)
        {
            var dataAccess = new DataAccess();
            return dataAccess.GetTransaction(new Guid(id));
        }

        // POST api/transaction
        [HttpPost]
        public void AddTransaction([FromBody] Transaction transaction)
        {
            var dataAccess = new DataAccess();
            dataAccess.AddTransaction(transaction);
        }

        // PUT api/transaction/5
        [HttpPut("{id}")]
        public void UpdateTransaction([FromBody] Transaction transaction)
        {
            var dataAccess = new DataAccess();
            dataAccess.UpdateTransaction(transaction);
        }

        // DELETE api/transaction/5
        [HttpDelete("{id}")]
        public void DeleteTransaction(string id)
        {
            var dataAccess = new DataAccess();
            dataAccess.DeleteTransaction(new Guid(id));
        }
    }
}