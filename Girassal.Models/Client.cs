using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models
{
    [Table("Client")]
    public  class Client : common
    {

        public string Name  { get; set; }
        public string Nuit { get; set; }
    }
}
