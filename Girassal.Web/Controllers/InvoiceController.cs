﻿using Girassol.Models;
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


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            var result = await _invoiceService.Read(int.Parse(id));
            return PartialView("Edit", result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Invoice model)
        {
            try
            {
                var result = await _invoiceService.Update(model);
                return RedirectToAction(nameof(Read));
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }



        [HttpGet]
        public async Task<IActionResult> status(string id)
        {

            var result = await _invoiceService.Read(int.Parse(id));
            return PartialView("status", result);
        }

        [HttpPost]
        public async Task<IActionResult> Status(Invoice model)
        {

            var result = await _invoiceService.Read(model.Id);
            if (result.Status == 0)
            {
                result.Status = 1;
            }
            else if (result.Status == 1)
            {
                result.Status = 0;
            }

            await _invoiceService.Update(result);

            return RedirectToAction(nameof(Read));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {

            var result = await _invoiceService.Read(int.Parse(id));
            return PartialView("Delete", result);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Invoice model)
        {
            await _invoiceService.Remove(model);
            return RedirectToAction(nameof(Read));
        }


        public async Task<IActionResult> Read()
        {

            return View(await _invoiceService.Read());
        }


    }
}