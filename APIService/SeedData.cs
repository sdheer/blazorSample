using APIService.Server;
using Data_Sharing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIService
{
    public class SeedData
    {
        public static void Initialize(StoreContext db)
        {
            var store = new Store[]
            {
                new Store()
                {
                    Name = "Pizza Hut",
                    ItemList = new List<Item>
                    {
                        new Item { Name = "Pizza", Price = 16 },
                        new Item { Name = "Hamberger", Price = 6 },
                        new Item { Name = "Spagheti", Price = 8 },
                        new Item { Name = "ChickenWings", Price = 6 },
                        new Item { Name = "Salad", Price = 4 }
                    }

                },
                new Store()
                {
                    Name= "McDonalds",
                    ItemList = new List<Item> {
                        new Item { Name = "Hamberger",Price=2},
                        new Item { Name = "Salad",Price=3}
                    }
                },
                new Store()
                {
                    Name = "Burger King",
                    ItemList = new List<Item>
                    {
                        new Item { Name = "Hamberger", Price =4 },
                        new Item { Name = "Spagheti", Price = 8 },
                        new Item { Name = "ChickenWings", Price = 5 },
                        new Item { Name = "Salad", Price = 5 }
                    }
                },
                new Store()
                {
                    Name = "Pizza Hut",
                    ItemList = new List<Item>
                    {
                        new Item { Name = "Hamberger", Price = 5},
                        new Item { Name = "ChickenWings", Price =4 },
                        new Item { Name = "Salad", Price = 5 }
                    }
                },
            };

            var users = new UserEntity[]
            {
                new UserEntity()
                {
                    Name = "User1",
                    Email= "test@mail.com",
                },
            };
            db.Stores.AddRange(store);
            db.Users.AddRange(users);
            db.SaveChanges();
        }
    }
}
