using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models
{
    [Table("Clothing")]
    public class Clothing : common
    {
        public SimpleEntity Type { get; set; }
        public int? SimpleEntityId { get; set; } 
        public int Quantity { get; set; }
    }
}
