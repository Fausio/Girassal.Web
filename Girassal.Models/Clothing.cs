using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Tipo")]
        public int? SimpleEntityId { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantity { get; set; }
    }
}
