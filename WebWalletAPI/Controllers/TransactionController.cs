﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebWalletAPI;
using WebWalletAPI.Models;

namespace WebWalletAPIAPI.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        // GET api/transaction
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            var dataAccess = new WebWalletAPI.Data.DataAccess();
            return dataAccess.GetTransactions();
        }

        // GET api/transaction/5
        [HttpGet("{id}")]
        public Transaction Get(string id)
        {
            var dataAccess = new WebWalletAPI.Data.DataAccess();
            return dataAccess.GetTransaction(new Guid(id));
        }

        // POST api/transaction
        [HttpPost]
        public void AddTransaction([FromBody]Transaction transaction)
        {
            var dataAccess = new WebWalletAPI.Data.DataAccess();
            dataAccess.AddTransaction(transaction);
        }

        // PUT api/transaction/5
        [HttpPut("{id}")]
        public void UpdateTransaction([FromBody]Transaction transaction)
        {
            var dataAccess = new WebWalletAPI.Data.DataAccess();
            dataAccess.UpdateTransaction(transaction);
        }

        // DELETE api/transaction/5
        [HttpDelete("{id}")]
        public void DeleteTransaction(string id)
        {
            var dataAccess = new WebWalletAPI.Data.DataAccess();
            dataAccess.DeleteTransaction(new Guid(id));
        }
    }
}