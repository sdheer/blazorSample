using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Sharing.Entities;
using APIService.Server;
using Microsoft.EntityFrameworkCore;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly StoreContext _db;

        public UserController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser()
        {
            var user = await _db.Users.Where(x=>x.Id>0).ToListAsync();
            if(user is not null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }

            //return Ok(new UserEntity { Id = 1, Name = "John Doe", Email = "johndoe@gmail.com" });

        }
        [HttpPost("SaveUser")]
        public async Task<IActionResult> SetUser(UserEntity user)
        {
            var status = await _db.Users.AnyAsync(x => x.Name == user.Name);
            if (!status)
            {
                return BadRequest($"{user.Name} already exist");
            }
            else
            {
                _ = await _db.AddAsync(user);
                return Ok();
            }
        }
    }
}
