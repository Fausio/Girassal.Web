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

            try
            {
                var data = await db.Users.ToListAsync();
                var passwordHashed = Password.Sha256();


             var   result = data.FirstOrDefault(x => x.Username == userName && x.Password == passwordHashed);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
