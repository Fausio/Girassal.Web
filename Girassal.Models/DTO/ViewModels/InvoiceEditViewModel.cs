using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models.DTO
{
    public class InvoiceEditViewModel : Invoice
    { 
        public string Name { get; set; }
        public string Nuit { get; set; }  
        public int Quantity { get; set; } 
        public int status { get; set; }

    }
}
