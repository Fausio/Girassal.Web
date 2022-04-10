using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models
{
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
        public string TodoIStToken { get; set; }
    }
}
