using APIService.Server;
using Data_Sharing.Entities;
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
    public class OrderController : ControllerBase
    {
        private readonly StoreContext _db;

        public OrderController(StoreContext db)
        {
            _db = db;
        }
        [HttpGet("getAllOrders")]
        public async Task<IActionResult> GetAllOrder()
        {
            var orders = _db.Orders.Include(it => it.Items).Where(x => x.OrderId != 0);
            if (orders.Count() > 0)
            {
                return Ok(orders.ToList());
            }
            else
            {
                return BadRequest("No Order found");
            }
        }
        [HttpPost("placeOrder")]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            await _db.Orders.AddAsync(order);
            try
            {
                if (_db.SaveChanges() > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Order cannot be placed at the moment");
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
