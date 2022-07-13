using APIService.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly StoreContext _db;
        public ItemController(StoreContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = _db.Items.Where(x => x.Id > 0);  
            if(items == null)
            {
                return BadRequest();
            }
            return Ok(items);
        }
    }
}
