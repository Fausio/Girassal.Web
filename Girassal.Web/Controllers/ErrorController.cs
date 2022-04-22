﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Girassol.Web.Controllers
{
    [Authorize]
    public class ErrorController : Controller
    {
        public IActionResult Page(string error)
        {
            return View("Page", error);
        }
    }
}