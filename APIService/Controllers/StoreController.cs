using APIService.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        private readonly StoreContext _db;

        public StoreController(StoreContext db)
        {
            _db = db;
        }
        [HttpGet("getStore")]
        public async Task<IActionResult> Index()
        {
            var stores = _db.Stores.Include(x => x.ItemList).Where(x => x.Id != 0);
            if(stores.Count()>0)
            {
                return Ok(stores);
            }
            return BadRequest();
        }
    }
}
