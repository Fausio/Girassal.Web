using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models.DTO.ViewModels
{
  public  class InvoiceTableViewModel :CommunVIewModel
    {

        public List<Invoice> Invoices;

       
         

        public InvoiceTableViewModel(List<Invoice> Invoices, int MessageStatus)
        {
            this.Invoices = Invoices;

            // 1 show sucess message
            // 0 num message
            this.MessageStatus = MessageStatus;
        }

    }
}
