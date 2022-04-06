using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models.DTO.ViewModels
{
    public class DashBoardViewModel
    {
        public InvoiceCreateOrEdiViewModel NewInvoice;


        public DashBoardViewModel(InvoiceCreateOrEdiViewModel model)
        {
            NewInvoice = model;
        }

        public int TotalInvoices      { get; set; }
        public int TotalInvoicesDone    { get; set; }
        public int TotalPendent         { get; set; }
        public int TotalClient          { get; set; }


    }
}
