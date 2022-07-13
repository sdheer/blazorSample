using BlazorServerApp.Data.Contract;
using Data_Sharing.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorServerApp.Data.Service
{
    public class StoreService : IStore
    {
        private readonly HttpClient httpClient;

        public StoreService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(Constants.Constants.BaseUrl);
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            var storedata = await httpClient.GetFromJsonAsync<IEnumerable<Store>>($"{ Constants.Constants.BaseUrl}Store/getStore");
            if (storedata is not null)
            {
                return storedata;
            }
            return null;
        }
        public async Task<bool> PlaceOrder(Order order)
        {
            var response = await httpClient.PostAsJsonAsync($"{ Constants.Constants.BaseUrl}Order/placeOrder", order);
            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        public async Task<IEnumerable<Order>> GetallOrders()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<Order>>($"{ Constants.Constants.BaseUrl}Order/getAllOrders");

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            return null;
        }
    }
}