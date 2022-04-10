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

        [AllowAnonymous]
        public IActionResult Login(string returUrl = "/")
        {
            return View(new Loginmodel { ReturnUrl = returUrl });
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Loginmodel model)
        {

            var user = await _IAccountServices.GetUSerNameAndPassord(model.UserName, model.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var claims = new List<Claim>();


            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));


            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = model.RememberMe });

            return LocalRedirect(model.ReturnUrl);
        }
    }
}
