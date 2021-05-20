using System;
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
        public IActionResult View1()
        {
            return View();
        }
        public IActionResult Games()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
            return RedirectToAction("View1");
        }
    }
}
