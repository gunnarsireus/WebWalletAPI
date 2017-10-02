using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebWalletAPI.Data;
using WebWalletAPI.Models;

namespace WebWalletAPI.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
	    private readonly UnitOfWork _unitOfWork;

	    public TransactionController()
	    {
		    _unitOfWork = new UnitOfWork(new WebWalletApiContext(new DbContextOptionsBuilder<WebWalletApiContext>().UseSqlite("DataSource=App_Data/WebWallet.db").Options));
	    }
		// GET api/transaction
		[HttpGet]
        public IEnumerable<Transaction> Get()
        {
	        return _unitOfWork.Transactions.GetAll();
		}

        // GET api/transaction/5
        [HttpGet("{id}")]
        public Transaction Get(string id)
        {
	        return _unitOfWork.Transactions.Get(new Guid(id));
		}

        // POST api/transaction
        [HttpPost]
        public void AddTransaction([FromBody] Transaction transaction)
        {
	        _unitOfWork.Transactions.Add(transaction);
	        _unitOfWork.Complete();
		}

        // PUT api/transaction/5
        [HttpPut("{id}")]
        public void UpdateTransaction([FromBody] Transaction transaction)
        {
	        _unitOfWork.Transactions.Update(transaction);
	        _unitOfWork.Complete();
		}

        // DELETE api/transaction/5
        [HttpDelete("{id}")]
        public void DeleteTransaction(string id)
        {
	        var transaction = _unitOfWork.Transactions.Get(new Guid(id));
	        _unitOfWork.Transactions.Remove(transaction);
	        _unitOfWork.Complete();
		}
    }
}