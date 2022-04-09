using ClosedXML.Excel;
using Girassol.Models;
using Girassol.Services.Interfaces.Invoice;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Girassol.Web.Controllers
{
    public class DocumentController : Controller
    {
        private IInvoiceService _invoiceService;
        public DocumentController(IInvoiceService invoice)
        {
            this._invoiceService = invoice;
        }

        [HttpPost]
        public async Task<IActionResult> Print(Invoice model)
        {


            try
            {
                var result = await _invoiceService.Read(model.Id);
                var CurrentDirectory = Environment.CurrentDirectory;
                var fileName = CurrentDirectory + @"\wwwroot\templates\fatura.xlsx";

                using (var workbook = new XLWorkbook(fileName, XLEventTracking.Enabled))
                {
                    var worksheet = workbook.Worksheets.FirstOrDefault();

                    worksheet.Cell("B4").Value = "Girassol Lavandaria";
                    worksheet.Cell("B5").Value = "AV. Ahmed Sekou /touré,";
                    worksheet.Cell("B6").Value = "nº 3479 R/C Cidade de Maputo, Alto-Maé";
                    worksheet.Cell("B7").Value = "+ 258 86 085 2222";

                    worksheet.Cell("G4").Value = "Nome: " + result.Client.Name;

                    if (!string.IsNullOrEmpty( result.Client.Nuit))
                    {

                        worksheet.Cell("G5").Value = "Nuit: " + result.Client.Nuit;
                    }

                    worksheet.Cell("B17").Value = result.Clothings.Quantity;
                    worksheet.Cell("D17").Value = result.Description;
                    worksheet.Cell("M17").Value = result.Price + " MZN";
                    worksheet.Cell("M32").Value = result.Price + " MZN";





                    var reportName = $"Fatura - {DateTime.Now.ToString()} - " + ".xlsx";

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                     
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", reportName);
                    }

                      
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Page","Error", new { error =@""+ ex.Message.ToString() });
            }


        }
    }
}
