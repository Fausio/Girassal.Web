using ClosedXML.Excel;
using Girassol.Data.Helpers;
using Girassol.Models;
using Girassol.Models.DTO.ViewModels;
using Girassol.Services.Interfaces.Invoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Girassol.Web.Controllers
{

    [Authorize]
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
                    #region up
                    var worksheet = workbook.Worksheets.FirstOrDefault();
                  
                    worksheet.Cell("B4").Value = "Girassol Lavandaria";
                    worksheet.Cell("B5").Value = "AV. Ahmed Sekou /touré,";
                    worksheet.Cell("B6").Value = "nº 3479 R/C Cidade de Maputo, Alto-Maé";
                    worksheet.Cell("B7").Value = "+ 258 86 085 2222";
                    worksheet.Cell("B9").Value = "Codigo: " + result.Code;

                    worksheet.Cell("G4").Value = "Nome: " + result.Client.Name;

                    if (!string.IsNullOrEmpty(result.Client.Nuit))
                    {

                        worksheet.Cell("G5").Value = "Nuit: " + result.Client.Nuit;
                    }
                    if (result.Client.Cell > 0)
                    {
                        worksheet.Cell("G5").Value = "Telefone: " + result.Client.Cell;
                    }

                    worksheet.Cell("B17").Value = result.Clothings.Quantity;
                    worksheet.Cell("D17").Value = result.Description;
                    worksheet.Cell("M17").Value = result.PriceWithIva + " MZN";
                    worksheet.Cell("M24").Value = result.Price + " MZN";

                    worksheet.Cell("M22").Value = result.IvaValue + " MZN";
                    #endregion


                    #region down 

                    worksheet.Cell("B40").Value = "Girassol Lavandaria";
                    worksheet.Cell("B41").Value = "AV. Ahmed Sekou /touré,";
                    worksheet.Cell("B42").Value = "nº 3479 R/C Cidade de Maputo, Alto-Maé";
                    worksheet.Cell("B43").Value = "+ 258 86 085 2222";
                    worksheet.Cell("B45").Value = "Codigo: " + result.Code;

                    worksheet.Cell("G40").Value = "Nome: " + result.Client.Name;

                    if (!string.IsNullOrEmpty(result.Client.Nuit))
                    {

                        worksheet.Cell("G41").Value = "Nuit: " + result.Client.Nuit;
                    }
                    if ( result.Client.Cell > 0)
                    { 
                        worksheet.Cell("G42").Value = "Telefone: " + result.Client.Cell;
                    }

                    worksheet.Cell("B52").Value = result.Clothings.Quantity;
                    worksheet.Cell("D52").Value = result.Description;
                    worksheet.Cell("M52").Value = result.PriceWithIva + " MZN";
                    worksheet.Cell("M59").Value = result.Price + " MZN";

                    worksheet.Cell("M57").Value = result.IvaValue + " MZN";
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

        //[Authorize(Roles = StringExtensions.RoleAdmin)]
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

                            int row = 14;

                            worksheet.Cell("A4").Value = "Girassol Lavandaria";
                            worksheet.Cell("A5").Value = "AV. Ahmed Sekou /touré,";
                            worksheet.Cell("A6").Value = "nº 3479 R/C Cidade de Maputo, Alto-Maé";
                            worksheet.Cell("A7").Value = "+ 258 86 085 2222";

                            worksheet.Cell("D4").Value = "Data inicial: " + model.StartdDate.Date;
                            worksheet.Cell("D5").Value = "Data final: " + model.EndDate.Date;


                            foreach (var x in result)
                            {
                                // bold font
                                worksheet.Cell(row, 1).Style.Font.Bold = true;
                                worksheet.Cell(row, 5).Style.Font.Bold = true;
                                worksheet.Cell(row, 6).Style.Font.Bold = true;

                                //data
                                worksheet.Cell(row, 1).Value = x.Id;
                                worksheet.Cell(row, 2).Value = x.Description;
                                worksheet.Cell(row, 3).Value = x.Clothings.Quantity;
                                worksheet.Cell(row, 4).Value = x.EntryDate.Date;
                                worksheet.Cell(row, 5).Value = x.PriceWithIva + " MZN";
                                worksheet.Cell(row, 6).Value = x.IvaValue + " MZN";
                                worksheet.Cell(row, 7).Value = x.Status == 0 ? "Processamento" : "Finalizada";

                                // font color
                                //worksheet.Cell(row, 6).Style.Font.FontColor = XLColor.FromArgb(255, 255, 255, 255);

                                //BackgroundColor
                                //if (x.Status == 0)
                                //{
                                //    worksheet.Cell(row, 6).Style.Fill.SetBackgroundColor(XLColor.FromArgb(254, 192, 192));
                                //}
                                //else
                                //{
                                //    worksheet.Cell(row, 6).Style.Fill.SetBackgroundColor(XLColor.FromArgb(254, 192, 192));
                                //}


                                row++;
                            }


                            var reportName = $"Retatório De Faturas - {DateTime.Now.ToString()} - " + ".xlsx";

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
