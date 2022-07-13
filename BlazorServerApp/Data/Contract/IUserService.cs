using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Sharing.Entities;
namespace BlazorServerApp.Data.Contract
{
    public interface IUserService
    {
        public Task<List<UserEntity>> SetUser();
        public bool GetUser(string name);
    }
}
