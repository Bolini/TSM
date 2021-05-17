﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TSM.Models;

namespace TSM.Controllers
{
    //[Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult view1()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
        }
    }
}
