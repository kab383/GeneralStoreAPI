using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeneralStoreAPI.Data;
using GeneralStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private GeneralStoreDBContext _db;
        public TransactionController(GeneralStoreDBContext db) {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactions([FromForm] TransactionEdit newTransaction) {
            Transaction transaction = new Transaction() {
                ProductId = newTransaction.ProductId,
                CustomerId = newTransaction.CustomerId,
                Quantity = newTransaction.Quantity,
                DateOfTransaction = DateTime.Now,
            };

            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions() {
            var transactions = await _db.Transactions.ToListAsync();
            return Ok(transactions);
        }
    }
}