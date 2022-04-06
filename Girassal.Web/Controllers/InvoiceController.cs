using Girassol.Models;
using Girassol.Models.DTO;
using Girassol.Services.Interfaces.Invoice;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Girassol.Web.Controllers
{
    public class InvoiceController : Controller
    {

        private IInvoiceService _invoiceService;


        public InvoiceController(IInvoiceService invoice)
        {
            this._invoiceService = invoice;
        }

        public async Task<IActionResult> create(Models.Invoice model)
        {
            await _invoiceService.Create(model);

            return RedirectToAction("Index", "Home");
        }




        [HttpPost]
        public async Task<IActionResult> Delete(string customerId)
        {
            // update here to show warning popup
            await _invoiceService.Remove(await _invoiceService.Read(int.Parse(customerId)));
             return PartialView("Delete", "");
        } 
        
        [HttpPost]
        public async Task<IActionResult> Edit(string customerId)
        {
            return PartialView("Edit", await _invoiceService.Read(int.Parse(customerId)));
        }

        public async Task<IActionResult> Read() => View(await _invoiceService.Read());


    }
}
