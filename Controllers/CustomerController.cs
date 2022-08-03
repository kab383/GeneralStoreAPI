using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeneralStoreAPI.Data;
using Microsoft.AspNetCore.Mvc;
using GeneralStoreAPI.Models;

namespace GeneralStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private GeneralStoreDBContext _db;
        public CustomerController(GeneralStoreDBContext db) {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerEdit newCustomer) {
            Customer customer = new Customer() {
                Name = newCustomer.Name,
                Email = newCustomer.Email,
            };

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}