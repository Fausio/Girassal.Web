using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Girassol.Models;
using Girassol.Models.DTO.ViewModels;

namespace Girassol.Services.Interfaces.Invoice
{
    public interface IInvoiceService
    {
        public Task Create(Models.Invoice invoice);
        public Task Remove(Models.Invoice invoice, int? updatedUserID);
        public Task<Models.Invoice> Update(Models.Invoice invoice, int? updatedUserID);
        public Task<List<Models.Invoice>> Read();
        public Task<Models.Invoice> Read(int id);

        public Task updateInvoiceQuantity();
        #region DashBoard 
        public Task<int> TotalInvoices();
        public Task<int> TotalInvoicesDone();
        public Task<int> TotalPendent ();
        public Task<int> TotalClient();
        public Task<List<Models.Invoice>> InvoiceWithParamiters(DownloadInvoiceViewModel model);
        #endregion

    }
}
