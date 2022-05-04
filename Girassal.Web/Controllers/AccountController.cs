using Girassol.Models;
using Girassol.Services.Interfaces.Account;
using Girassol.Services.Interfaces.Invoice;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Girassol.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountServices _IAccountServices;
        public AccountController(IAccountServices IAccountServices)
        {
            this._IAccountServices = IAccountServices;
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
         
        public  IActionResult  AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returUrl = "/", string msg = "")
        {
            ViewBag.msg = msg;

            return View(new Loginmodel { ReturnUrl = returUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Loginmodel model)
        {

            try
            {
                var user = await _IAccountServices.GetUSerNameAndPassord(model.UserName, model.Password);

                if (user == null)
                { 
                    return RedirectToAction("Login", "Account", new { msg ="User invalido" });
                }

                var claims = new List<Claim>();


                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, user.Name));
                claims.Add(new Claim(ClaimTypes.Role, user.Role));


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = model.RememberMe });

                return LocalRedirect(model.ReturnUrl);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Page", "Error", new { error = @"" + ex.Message.ToString() });
            }


        }


    }
}
