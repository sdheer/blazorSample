using Data_Sharing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Data.Contract
{
    public interface IStore
    {
        public Task<IEnumerable<Store>> GetStores();
        public Task<bool> PlaceOrder(Order order);
        public Task<IEnumerable<Order>> GetallOrders();
    }
}
