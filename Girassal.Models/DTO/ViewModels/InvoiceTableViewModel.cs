using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Models.DTO.ViewModels
{
  public  class InvoiceTableViewModel
    {

        public List<Invoice> Invoices;

        // 1 show sucess message
        // 0 num message

        public int MessageStatus;

        public InvoiceTableViewModel(List<Invoice> Invoices, int MessageStatus)
        {
            this.Invoices = Invoices;
            this.MessageStatus = MessageStatus;
        }

    }
}
