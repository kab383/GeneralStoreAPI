using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeneralStoreAPI.Data;

namespace GeneralStoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private GeneralStoreDBContext _db;
        public ProductController(GeneralStoreDBContext db) {
            _db = db;
        }
    }
}