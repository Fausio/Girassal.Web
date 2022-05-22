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
                        CreatedDate = DateTime.Now.Date,
                        Guid = Guid.NewGuid(),
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

                return RedirectToAction("Index", "Home", new
                {

                    EntryDate = model.EntryDate.Date,
                    Name = model.Client.Name,
                    Nuit = model.Client.Nuit,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    Description = model.Description,
                    MessageStatus = 1,
                    MessageText = "A data de entrada não pode ser maior que a data actual Ou Inferior a um mês",
                });
            }


            foreach (var item in model.Clothings)
            {
                model.Price = model.Price + item.Price;
            }


            if (model.Price <= 0)
            {
                return RedirectToAction("Index", "Home", new
                {

                    EntryDate = model.EntryDate.Date,
                    Name = model.Client.Name,
                    Nuit = model.Client.Nuit,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    Description = model.Description,
                    MessageStatus = 1,
                    MessageText = "Preço Invalido"
                });
            }
            if (string.IsNullOrWhiteSpace(model.Client.Name) || string.IsNullOrWhiteSpace(model.Client.Name))
            {
                return RedirectToAction("Index", "Home", new
                {

                    EntryDate = model.EntryDate.Date,
                    Name = model.Client.Name,
                    Nuit = model.Client.Nuit,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    Description = model.Description,
                    MessageStatus = 1,
                    MessageText = "O nome do Cliente é obrigatório"
                });
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
                CurrentUserId = await _IAccountServices.GetUserId(User.Identity.Name);
                model.UpdatedUserID = CurrentUserId;


                model.Price = 0;
                foreach (var item in model.Clothings)
                {
                    model.Price = model.Price + item.Price;
                    item.UpdatedUserID = CurrentUserId;
                }

                var result = await _invoiceService.Update(model);
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
            await _invoiceService.Remove(model);
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
