using Girassol.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Services.Interfaces.Account
{
    public interface IAccountServices
    { 
        Task<User> GetUSerNameAndPassord(string userName, string Password);
        Task CreateUser(User user); 
        Task<int> GetUserId(string userName);
    }
}
