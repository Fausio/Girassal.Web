using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models
{
    [Table("User")]
    public class User : common
    {
        

        public string Name { get; set; }
        public string Initials { get; set; }
        public string FullName { get; set; }

        [DisplayName("Utilizador")]
        public string Username { get; set; }
        public string Email { get; set; }

        [DisplayName("Senha")]
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Blocked { get; set; }

       
    }
}
