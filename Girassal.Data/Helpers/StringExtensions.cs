using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Data.Helpers
{

    public static class StringExtensions
    {
        public const string RoleAdmin = "Admin";
        public const string RoleNormal = "Normal";
        public const string RoleAll = "Normal,Admin";

        public enum ModelState
        {
            Read = 0 ,
            Delete = 1
        }

        public static string Sha256(this string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);


                return Convert.ToBase64String(hash);
            }
        }
    }
}
