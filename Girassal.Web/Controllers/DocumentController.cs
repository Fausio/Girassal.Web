using ClosedXML.Excel;
using Girassol.Data.Helpers;
using Girassol.Models;
using Girassol.Models.DTO.ViewModels;
using Girassol.Services.Interfaces.Invoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Girassol.Web.Controllers
{

    [Authorize]
    public class DocumentController : Controller
    {
        private IInvoiceService _invoiceService;
        private readonly UserManager<IdentityUser> _userManager;
        public DocumentController(IInvoiceService invoice, UserManager<IdentityUser> userManager)
        {
            this._invoiceService = invoice;
            this._userManager = userManager;
        }



        [HttpPost]
        public async Task<IActionResult> Print(Invoice model)
        {


            try
            {
                var result = await _invoiceService.Read(model.Id);
                var CurrentDirectory = Environment.CurrentDirectory;
                var fileName = CurrentDirectory + @"\wwwroot\templates\fatura_p25_.xlsx";

                using (var workbook = new XLWorkbook(fileName, XLEventTracking.Enabled))
                {
                    #region up
                    var worksheet = workbook.Worksheets.FirstOrDefault();

                    worksheet.Cell("A8").Value = "Recibo: " + result.Code;
                    worksheet.Cell("A9").Value = "Data: " + DateTime.Now.ToShortDateString();

                    worksheet.Cell("A11").Value = "Cliente: " + result.Client.Name;

                    if (!string.IsNullOrEmpty(result.Client.Nuit))
                    {

                        worksheet.Cell("A12").Value = "Nuit: " + result.Client.Nuit;
                    }
                    if (result.Client.Cell > 0)
                    {
                        worksheet.Cell("A13").Value = "Tel: " + result.Client.Cell;
                    }


                    int row = 16;
                    foreach (var item in result.Clothings)
                    {
                        worksheet.Cell(row, 1).Value = item.Description;
                        worksheet.Cell(row, 2).Value = item.Price + " MZN";

                        row++;
                    }

                    worksheet.Cell(string.Format("B{0}", row + 1)).Value = "Iva: " + result.PriceWithIva + " MZN";
                    worksheet.Cell(string.Format("B{0}", row + 2)).Value = "Iva: " + result.IvaValue + " MZN";
                    worksheet.Cell(string.Format("B{0}", row + 3)).Value = "Total: " + result.Price + " MZN";

                    worksheet.Cell(string.Format("A{0}", row + 5)).Value = "TERMOS: Nenhum";
                    worksheet.Cell(string.Format("A{0}", row + 6)).Value = "===============";

                    worksheet.Cell(string.Format("A{0}", row + 7)).Value = "";


                    #endregion


                    #region down  



                    row = row + 8;

                    worksheet.Cell(string.Format("A{0}", row + 1)).Value = "Girassol Lavandaria: ";
                    worksheet.Cell(string.Format("A{0}", row + 2)).Value = "AV. Ahmed Sekou /touré,: ";
                    worksheet.Cell(string.Format("A{0}", row + 3)).Value = "nº 3479 R/C  Maputo: ";
                    worksheet.Cell(string.Format("A{0}", row + 4)).Value = "Alto-Maé: ";
                    worksheet.Cell(string.Format("A{0}", row + 5)).Value = "+ 258 86 085 2222: ";

                    row = row + 7;
                     

                    worksheet.Cell(string.Format("A{0}", row + 1)).Value = "Recibo: " + result.Code;
                    worksheet.Cell(string.Format("A{0}", row + 2)).Value = "Data: " + DateTime.Now.ToShortDateString();
                    worksheet.Cell(string.Format("A{0}", row + 3)).Value = "Cliente: " + result.Client.Name;

                    if (!string.IsNullOrEmpty(result.Client.Nuit))
                    {

                        worksheet.Cell(string.Format("A{0}", row + 4)).Value = "Nuit: " + result.Client.Nuit;
                    }
                    if (result.Client.Cell > 0)
                    {
                        worksheet.Cell(string.Format("A{0}", row + 5)).Value = "Tel: " + result.Client.Cell;
                    }

                    row = row + 7;

                    worksheet.Cell(row, 1).Value = "Itens";
                    worksheet.Cell(row, 2).Value = "Preço";


                    row++;

                    foreach (var item in result.Clothings)
                    {
                        worksheet.Cell(row, 1).Value = item.Description;
                        worksheet.Cell(row, 2).Value = item.Price + " MZN";

                        row++;
                    }

                    worksheet.Cell(string.Format("B{0}", row + 1)).Value = "Iva: " + result.PriceWithIva + " MZN";
                    worksheet.Cell(string.Format("B{0}", row + 2)).Value = "Iva: " + result.IvaValue + " MZN";
                    worksheet.Cell(string.Format("B{0}", row + 3)).Value = "Total: " + result.Price + " MZN";

                    worksheet.Cell(string.Format("A{0}", row + 5)).Value = "TERMOS: Nenhum";
                    worksheet.Cell(string.Format("A{0}", row + 6)).Value = "===============";
                     
                    worksheet.Cell(string.Format("A{0}", row + 7)).Value = ".";
                    worksheet.Cell(string.Format("A{0}", row + 8)).Value = ".";
                    worksheet.Cell(string.Format("A{0}", row + 9)).Value = ".";
                    #endregion

                    worksheet.Protect();

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
                return RedirectToAction("Page", "Error", new { error = @"" + ex.Message.ToString() });
            }


        }

        [Authorize(Roles = StringExtensions.RoleAdmin)]
        public async Task<IActionResult> InvoiceIndex(int MessageStatus = 0)
        {
            try
            {

                var model = new DownloadInvoiceViewModel()
                {
                    MessageStatus = MessageStatus
                };

                if (MessageStatus == 1)
                {
                    model.MessageText = "Sem dados, Por favor tente novamente com parametros diferentes.";
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Page", "Error", new { error = @"" + ex.Message.ToString() });
            }
        }

        [HttpPost]
        //[Authorize(Roles = StringExtensions.RoleAdmin)]
        public async Task<IActionResult> DownloadInvoiceWithParamiters(DownloadInvoiceViewModel model)
        {
            try
            {
                var result = await _invoiceService.InvoiceWithParamiters(model);

                if (result != null)
                {
                    try
                    {

                        var CurrentDirectory = Environment.CurrentDirectory;
                        var fileName = CurrentDirectory + @"\wwwroot\templates\faturaResumed.xlsx";



                        using (var workbook = new XLWorkbook(fileName, XLEventTracking.Enabled))
                        {
                            var worksheet = workbook.Worksheets.FirstOrDefault();

                            int row = 13;

                            worksheet.Cell("A4").Value = "Girassol Lavandaria";
                            worksheet.Cell("A5").Value = "AV. Ahmed Sekou /touré,";
                            worksheet.Cell("A6").Value = "nº 3479 R/C Cidade de Maputo, Alto-Maé";
                            worksheet.Cell("A7").Value = "+ 258 86 085 2222";

                            worksheet.Cell("E4").Value = "Data inicial: " + model.StartdDate.Date.ToShortDateString();
                            worksheet.Cell("E5").Value = "Data final: " + model.EndDate.Date.ToShortDateString();


                            foreach (var x in result)
                            {
                                // bold font
                                worksheet.Cell(row, 2).Style.Font.Bold = true;
                                worksheet.Cell(row, 6).Style.Font.Bold = true;
                                worksheet.Cell(row, 7).Style.Font.Bold = true;
                                worksheet.Cell(row, 8).Style.Font.Bold = true;

                                //data
                                worksheet.Cell(row, 1).Value = x.Id;
                                worksheet.Cell(row, 2).Value = x.Code;



                                worksheet.Cell(row, 3).Value = string.Join(", ", x.Clothings.Select(p => p.Description));
                                worksheet.Cell(row, 4).Value = x.Clothings.Count;
                                worksheet.Cell(row, 5).Value = x.EntryDate;
                                worksheet.Cell(row, 6).Value = x.Price + " MZN";
                                worksheet.Cell(row, 7).Value = x.PriceWithIva + " MZN";
                                worksheet.Cell(row, 8).Value = x.IvaValue + " MZN";
                                worksheet.Cell(row, 9).Value = x.Status == 0 ? "Processamento" : "Finalizada";

                                row++;
                            }


                            var reportName = $"Retatório De Faturas - {DateTime.Now.ToString()} - " + ".xlsx";

                            worksheet.Protect();

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
                        return RedirectToAction("Page", "Error", new { error = @"" + ex.Message.ToString() });
                    }
                }
                else

                    return RedirectToAction("InvoiceIndex", "Document", new { MessageStatus = 1 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Page", "Error", new { error = @"" + ex.Message.ToString() });
            }
        }
    }
}
