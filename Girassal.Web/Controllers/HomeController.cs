using Girassol.Data.Seeds;
using Girassol.Models;
using Girassol.Models.DTO.ViewModels;
using Girassol.Services.Interfaces.Invoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Girassal.Web.Controllers
{
    public class HomeController : Controller
    {
        private IInvoiceService _invoiceService;
        private DashBoardViewModel HomeModel;


        public HomeController(IInvoiceService invoiceService)
        {

            _invoiceService = invoiceService;
            this.HomeModel = new DashBoardViewModel(new Invoice()
            {
                EntryDate = DateTime.Now.Date,
                Client = new Client(),
                Clothings = new Clothing()
            })
            {

                TotalInvoices = _invoiceService.TotalInvoices().Result,
                TotalInvoicesDone = _invoiceService.TotalInvoicesDone().Result,
                TotalPendent = _invoiceService.TotalPendent().Result,
                TotalClient = _invoiceService.TotalClient().Result

            };
        }

        public async Task<IActionResult> Index(

            DateTime EntryDate,
            string Name = "bb",
            string Nuit = "",
            int Quantity = 0,
            Decimal Price = 0,
            string Description = "",
            int MessageStatus = 0,
            string MessageText = ""

            )
        {
            if (EntryDate > DateTime.Now.AddYears(-1))
            {
                this.HomeModel.Invoice.EntryDate = EntryDate;
            }



            this.HomeModel.Invoice.Client.Name = Name;
            this.HomeModel.Invoice.Client.Nuit = Nuit;
            this.HomeModel.Invoice.Clothings.Quantity = Quantity;
            this.HomeModel.Invoice.Price = Price;
            this.HomeModel.Invoice.Description = Description;
            this.HomeModel.MessageStatus = MessageStatus;
            this.HomeModel.MessageText = MessageText;

            return View(this.HomeModel);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
