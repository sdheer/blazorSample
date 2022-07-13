using BlazorServerApp.Data.Contract;
using Data_Sharing.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using BlazorServerApp.Constants;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace BlazorServerApp.Data.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(Constants.Constants.BaseUrl);
        }
        public async Task<List<UserEntity>> SetUser()
        {

            var user = await httpClient.GetFromJsonAsync<List<UserEntity>>($"{ Constants.Constants.BaseUrl}User/getUser");

            return user;
        }
        public bool GetUser(string name)
        {
            var userdata = httpClient.GetFromJsonAsync<UserEntity>($"{ Constants.Constants.BaseUrl}User/getUser/{name}");
            return userdata != null;
        }
    }
}
