using Girassal.Data.Data;
using Girassol.Models;
using Girassol.Services.Interfaces.Invoice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Services.Services.Invoices
{
    public class InvoicesService : IInvoiceService
    {
        private ApplicationDbContext db;

        public InvoicesService()
        {
            db = new ApplicationDbContext();
        }

        public async Task Create(Invoice invoice)
        {


            try
            {
                await db.AddAsync(invoice);
                await db.SaveChangesAsync();
            }
            catch (Exception x)
            {

                throw x;
            }

        }

        public async Task<List<Invoice>> Read()
        {
            return await db.Invoice.Include(x => x.Client)
                                   .Include(x => x.Clothings)
                                   .ToListAsync();
        }

        public async Task<Invoice> Read(int id) => await db.Invoice.Include(x => x.Clothings).Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == id);

        public async Task Remove(Invoice invoice)
        {
            db.Remove(invoice);
            await db.SaveChangesAsync();
        }

        public async Task<Invoice> Update(Invoice invoice)
        {
            db.Update(invoice);
            await db.SaveChangesAsync();

            return invoice;
        }


        #region Dashboard
        public async Task<int> TotalInvoices() => await db.Invoice.CountAsync();
        public async Task<int> TotalInvoicesDone() => await db.Invoice.CountAsync(x => x.Status == 1);
        public async Task<int> TotalPendent() => await db.Invoice.CountAsync(x => x.Status == 0);
        public async Task<int> TotalClient() => await db.Client.CountAsync(x => x.Status == 1);

        #endregion
    }
}
