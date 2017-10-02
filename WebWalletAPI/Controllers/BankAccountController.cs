using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebWalletAPI.Data;
using WebWalletAPI.Models;

namespace WebWalletAPI.Controllers
{
    [Route("api/[controller]")]
    public class BankAccountController : Controller
    {
	    private readonly UnitOfWork _unitOfWork;
	    public BankAccountController()
	    {
			_unitOfWork = new UnitOfWork(new WebWalletApiContext(new DbContextOptionsBuilder<WebWalletApiContext>().UseSqlite("DataSource=App_Data/WebWallet.db").Options));
		}
        // GET api/bankaccount
        [HttpGet]
        public IEnumerable<BankAccount> GetBankAccounts()
        {
	        return _unitOfWork.BankAccounts.GetAll();
        }

        // GET api/bankaccount/5
        [HttpGet("{id}")]
        public BankAccount GetBankAccount(string id)
        {
	        return _unitOfWork.BankAccounts.Get(new Guid(id));
		}

        // POST api/bankaccount
        [HttpPost]
        public void AddBankAccount([FromBody] BankAccount bankAccount)
        {
	        _unitOfWork.BankAccounts.Add(bankAccount);
	        _unitOfWork.Complete();
		}

        // PUT api/bankaccount/5
        [HttpPut("{id}")]
        public void UpdateBankAccount([FromBody] BankAccount bankAccount)
        {
	        _unitOfWork.BankAccounts.Update(bankAccount);
			_unitOfWork.Complete();
        }

        // DELETE api/bankaccount/5
        [HttpDelete("{id}")]
        public void DeleteBankAccount(string id)
        {
	        var account = _unitOfWork.BankAccounts.Get(new Guid(id));
			_unitOfWork.BankAccounts.Remove(account);
	        _unitOfWork.Complete();
		}
    }
}