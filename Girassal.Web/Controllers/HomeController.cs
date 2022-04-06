using Girassol.Data.Seeds;
using Girassol.Models;
using Girassol.Models.DTO.ViewModels;
using Girassol.Services.Interfaces.Invoice;
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

        public HomeController(IInvoiceService invoiceService)
        {

            _invoiceService = invoiceService;
        }

        public async Task<IActionResult> Index()
        {

            return View(
                        new DashBoardViewModel(new InvoiceCreateOrEdiViewModel())
                        {
                            TotalInvoices = await _invoiceService.TotalInvoices(),
                            TotalInvoicesDone = await _invoiceService.TotalInvoicesDone(),
                            TotalPendent = await _invoiceService.TotalPendent(),
                            TotalClient = await _invoiceService.TotalClient()
                        }
                ); ; ;
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
