using Girassal.Data.Data;
using Girassol.Data.Helpers;
using Girassol.Models;
using Girassol.Services.Interfaces.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Services.Services.Account
{
    public class AccountServices : IAccountServices
    {

        private ApplicationDbContext db;

        public AccountServices()
        {
            db = new ApplicationDbContext();
        }

        public async Task CreateUser(User model)
        {
            await db.Users.AddAsync(model);
            await db.SaveChangesAsync();
        }

        public async Task<User> GetUSerNameAndPassord(string userName, string Password)
        {
            var result = await db.Users.FirstOrDefaultAsync(x => x.Username == userName && x.Password == Password.Sha256());

            return result;
        }
    }
}
