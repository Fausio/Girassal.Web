using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models
{
    [Table("Invoice")]

    // status
    //0 pendent  invoice
    //1 done invoice
    public class Invoice : common
    {
        public Clothing Clothings { get; set; }
        public Client Client { get; set; }
        public int? ClientId { get; set; }

        [Display(Name = "Data de Entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:MM}")]
        public DateTime EntryDate { get; set; }

        [Display(Name = "Preço")]
        public Decimal Price { get; set; }

        [Display(Name = "Preço com IVA")]
        public Decimal PriceWithIva { get; set; }
    }
}
