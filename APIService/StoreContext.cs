using Data_Sharing.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APIService.Server
{
    public class StoreContext : DbContext
    {
        public StoreContext(
            DbContextOptions options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserEntity> Users  { get; set; }
    }
}
