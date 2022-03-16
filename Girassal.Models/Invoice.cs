using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models
{
    [Table("Invoice")]
    public class Invoice : common
    {
        public Invoice()
        {
            this.Clothings = new List<Clothing>();
        }
        public List<Clothing> Clothings { get; set; }

        public Client Client { get; set; }
        public int? ClientId { get; set; }

        public DateTime EntryDate { get; set; }
         
    }
}
