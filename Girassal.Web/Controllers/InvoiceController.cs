using Girassol.Data.Helpers;
using Girassol.Models;
using Girassol.Models.DTO;
using Girassol.Models.DTO.ViewModels;
using Girassol.Services.Interfaces.Account;
using Girassol.Services.Interfaces.Invoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Girassol.Web.Controllers
{
    [Authorize()]
    public class InvoiceController : Controller
    {

        private IInvoiceService _invoiceService;
        private readonly UserManager<IdentityUser> _userManager;
        private IAccountServices _IAccountServices;
        private int CurrentUserId;

        public InvoiceController(IInvoiceService invoice, UserManager<IdentityUser> userManager, IAccountServices IAccountServices)
        {
            this._invoiceService = invoice;
            this._userManager = userManager;
            this._IAccountServices = IAccountServices;

        }



        public async Task<IActionResult> create(Invoice model)
        {
            CurrentUserId = await _IAccountServices.GetUserId(User.Identity.Name);

            if (model.Quantity > 0)
            {



                for (int i = 0; i < model.Quantity; i++)
                {
                    model.Clothings.Add(new Clothing()
                    {
                        Quantity = 1,
                        CreatedUserID = CurrentUserId
                    });
                }

                model.CreatedUserID = CurrentUserId;
                model.EntryDate = DateTime.Now.Date;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home", new
                {
                    MessageText = "Falha: A quantidade deve ser maior que zero !",
                });
            }
        }


        [HttpPost]
        public async Task<IActionResult> createInvoice(Invoice model)
        {

            if (model.EntryDate.Date > DateTime.Now.Date || model.EntryDate.Date < DateTime.Now.AddMonths(-1))
            {
                TempData["MessageText"] = "A data de entrada não pode ser maior que a data actual Ou Inferior a um mês";
                return View(model);
            }

            foreach (var item in model.Clothings)
            {
                if (item.Price <= 0)
                {
                    TempData["MessageText"] = $"Preço Invalido para o Item: {item.Description}";
                    return View(model);
                }
                if (item.Quantity <= 0)
                {
                    TempData["MessageText"] = $"Quantidade Invalida para o Item: {item.Description}";
                    return View(model);
                }
            }

            if (string.IsNullOrWhiteSpace(model.Client.Name) || string.IsNullOrWhiteSpace(model.Client.Name))
            {
                TempData["MessageText"] = "O nome do Cliente é obrigatório";
                return View(model);
            }

            await _invoiceService.Create(model);

            return RedirectToAction("Read", "Invoice", new { statusMessage = 1 });
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
                if (model.EntryDate.Date > DateTime.Now.Date || model.EntryDate.Date < DateTime.Now.AddMonths(-1))
                {
                    TempData["MessageText"] = $"Fatura:{model.Code}, A data de entrada não pode ser maior que a data actual Ou Inferior a um mês";
                    return RedirectToAction(nameof(Read) );
                }

                foreach (var item in model.Clothings)
                {
                    if (item.Price <= 0)
                    {
                        TempData["MessageText"] = $"Fatura:{model.Code}, Preço Invalido para o Item: {item.Description}";
                        return RedirectToAction(nameof(Read));
                    }
                    if (item.Quantity <= 0)
                    {
                        TempData["MessageText"] = $"Fatura:{model.Code}, Quantidade Invalida para o Item: {item.Description}";
                        return RedirectToAction(nameof(Read));
                    }
                }

                if (string.IsNullOrWhiteSpace(model.Client.Name) || string.IsNullOrWhiteSpace(model.Client.Name))
                if (string.IsNullOrWhiteSpace(model.Client.Name) || string.IsNullOrWhiteSpace(model.Client.Name))
                {
                    TempData["MessageText"] = $"Fatura:{model.Code}, O nome do Cliente é obrigatório";
                    return RedirectToAction(nameof(Read));
                }

                CurrentUserId = await _IAccountServices.GetUserId(User.Identity.Name);

                var result = await _invoiceService.Update(model, CurrentUserId);
                return RedirectToAction(nameof(Read), new { statusMessage = 1 });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public async Task<IActionResult> status(string id)
        {


            var Role = User.FindFirstValue(ClaimTypes.Role);// will give the user's Email
            var result = await _invoiceService.Read(int.Parse(id));

            if (result.Status == 0)
            {
                return PartialView("status", result);
            }
            else if (result.Status == 1 && Role == StringExtensions.RoleAdmin)
            {
                return PartialView("status", result);
            }
            else
            {
                result.Status = 2;
                return PartialView("status", result);
            }


        }

        [HttpPost]
        public async Task<IActionResult> Status(Invoice model)
        {
            CurrentUserId = await _IAccountServices.GetUserId(User.Identity.Name);

            var result = await _invoiceService.Read(model.Id);
            if (result.Status == 0)
            {
                result.Status = 1;
            }
            else if (result.Status == 1)
            {
                result.Status = 0;
            }

            await _invoiceService.Update(result, CurrentUserId); 
            return RedirectToAction(nameof(Read), new { statusMessage = 1 });
        }


        [HttpGet]
        public async Task<IActionResult> Print(string id)
        {
            var result = await _invoiceService.Read(int.Parse(id));
            return PartialView("Print", result);
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
            CurrentUserId = await _IAccountServices.GetUserId(User.Identity.Name);
            await _invoiceService.Remove(model, CurrentUserId);
            return RedirectToAction(nameof(Read), new { statusMessage = 1 });
        }


        public async Task<IActionResult> Read(int statusMessage = 0)
        {
            // 1 show sucess message
            // 0 num message
            var model = await _invoiceService.Read();


            return View(new InvoiceTableViewModel(model, statusMessage));
        }


    }
}
