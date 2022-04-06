using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Girassol.Models;

namespace Girassol.Services.Interfaces.Invoice
{
    public interface IInvoiceService
    {
        public Task Create(Models.Invoice invoice);
        public Task Remove(Models.Invoice invoice);
        public Task<Models.Invoice> Update(Models.Invoice invoice);
        public Task<List<Models.Invoice>> Read();
        public Task<Models.Invoice> Read(int id);


        #region DashBoard 
        public Task<int> TotalInvoices();
        public Task<int> TotalInvoicesDone();
        public Task<int> TotalPendent ();
        public Task<int> TotalClient();
        #endregion

    }
}
