using BlazorServerApp.Data.Contract;
using Data_Sharing.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages
{
    public class UserBase : ComponentBase
    {
        [Inject]
        private IUserService UserService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        public UserEntity User { get; set; }
        public List<UserEntity> AllUsers { get; set; }
        public string userInput { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await FetchData(); 
        }
        public void getUser()
        {
            if (!string.IsNullOrWhiteSpace(userInput))
            {
               var status = AllUsers.FirstOrDefault(x => x.Name == userInput);
                if (status!=null )
                {
                    var id = status.Id;
                    NavigationManager.NavigateTo($"/fetchdata/{id}");
                }
            }

        }
        public async Task<List<UserEntity>> FetchData()
        {
            AllUsers = await this.UserService.SetUser();
            return AllUsers;
        }
    }
}
