using Girassal.Data.Data;
using Girassol.Models;
using Girassol.Models.DTO.ViewModels;
using Girassol.Services.helpers;
using Girassol.Services.Interfaces.Invoice;
using Microsoft.Data.SqlClient;
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
        private decimal GetPriceWithIva(decimal price) => price / 117 * 100;
        private decimal GetIvaValue(decimal Price, decimal priceWithIva) => Price - priceWithIva;
        private decimal GetTotalPrice(List<Clothing> model)
        {
            decimal totaPrice = 0;

            foreach (var item in model)
            {
                totaPrice += item.Quantity * item.Price;
            }

            return totaPrice;
        }
        public async Task Create(Invoice invoice)
        {
            DateTime now = DateTime.Now;


            try
            {
                invoice.Price = GetTotalPrice(invoice.Clothings);
                invoice.CreatedDate = now;
                invoice.Guid = Guid.NewGuid();
                invoice.Clothings.ForEach(x =>
                {
                    x.Guid = Guid.NewGuid();
                    x.CreatedDate = now;
                });

                invoice.PriceWithIva = GetPriceWithIva(invoice.Price);
                invoice.IvaValue = GetIvaValue(invoice.Price, invoice.PriceWithIva);


                await db.AddAsync(invoice);
                await db.SaveChangesAsync();

                invoice.Code = "GL-" + invoice.Id.ToString();
                db.Update(invoice);
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
                                   .OrderByDescending(x => x.Id)
                                   .Where(x => x.State == 0).ToListAsync();
        }

        public async Task<Invoice> Read(int id)
        {
            try
            {
                var result = await db.Invoice.Include(x => x.Clothings).Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == id && x.State == 0);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Remove(Invoice invoice, int? updatedUserID)
        {
            invoice = await Read(invoice.Id);
            invoice.State = 1;// deleted  
            await Update(invoice, updatedUserID);
        }

        public async Task<Invoice> Update(Invoice invoice, int? updatedUserID)
        {
            DateTime now = DateTime.Now;

            try
            {
                invoice.UpdatedUserID = updatedUserID;
                invoice.UpdatedDate = now;
                invoice.Price = GetTotalPrice(invoice.Clothings);
                invoice.Clothings.ForEach(x =>
                {
                    x.UpdatedDate = now;
                    x.UpdatedUserID = updatedUserID;
                });

                invoice.PriceWithIva = GetPriceWithIva(invoice.Price);
                invoice.IvaValue = GetIvaValue(invoice.Price, invoice.PriceWithIva);

                db.Update(invoice);
                await db.SaveChangesAsync();

                return invoice;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        #region Dashboard
        public async Task<int> TotalInvoices() => await db.Invoice.CountAsync(x => x.State == 0);
        public async Task<int> TotalInvoicesDone() => await db.Invoice.CountAsync(x => x.Status == 1 && x.State == 0);
        public async Task<int> TotalPendent() => await db.Invoice.CountAsync(x => x.Status == 0 && x.State == 0);
        public async Task<int> TotalClient() => await db.Client.CountAsync();

        public async Task<List<Invoice>> InvoiceWithParamiters(DownloadInvoiceViewModel model)
        {



            if (model.Finalized && model.Processing)
            {
                return await db.Invoice.Where(x => x.EntryDate.Date >= model.StartdDate.Date && x.EntryDate.Date <= model.EndDate.Date && x.State == 0)
                                   .Include(x => x.Client)
                                   .Include(x => x.Clothings)
                                   .OrderByDescending(x => x.Id)
                                   .ToListAsync();

            }

            if (model.Finalized && !model.Processing)
            {
                return await db.Invoice.Where(x => x.Status == 1 && (x.EntryDate.Date >= model.StartdDate.Date && x.EntryDate.Date <= model.EndDate.Date) && x.State == 0)
                                .Include(x => x.Client)
                                .Include(x => x.Clothings)
                                .OrderByDescending(x => x.Id)
                                .ToListAsync();
            }

            if (!model.Finalized && model.Processing)
            {
                return await db.Invoice.Where(x => x.Status == 0 && (x.EntryDate.Date >= model.StartdDate.Date && x.EntryDate.Date <= model.EndDate.Date) && x.State == 0)
                                .Include(x => x.Client)
                                .Include(x => x.Clothings)
                                .OrderByDescending(x => x.Id)
                                .ToListAsync();
            }
            else
            {
                return null;
            }

        }

        public async Task updateInvoiceQuantity()
        {
 

            var commandText = Querys.updateInvoiceQuantity; 
            await db.Database.ExecuteSqlRawAsync(commandText);
             
        }

        #endregion
    }
}
