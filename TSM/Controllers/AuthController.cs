using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TSM.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TSM.Controllers
{
    //[Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                CurrentUser = "David";                  // Test
                ViewData["CurrentUser"] = CurrentUser;  // Test
                return RedirectToAction("View1");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string s)
        {
            CurrentUser = s;
            ViewData["CurrentUser"] = CurrentUser;
            return RedirectToAction("View1");
        }

        public IActionResult View1()
        {
            ViewData["CurrentUser"] = CurrentUser;
            return View();
        }
        public IActionResult Games()
        {
            return View();
        }
        public IActionResult Game1()
        {
            return View();
        }

        public IActionResult Chat()
        {
            ViewData["CurrentUser"] = CurrentUser;
            return View();
        }

        public IActionResult Messages()
        {
            //hämta och skicka lista på vänner från db till vy när möjligt
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            CurrentUser = "David";                  // Test
            ViewData["CurrentUser"] = CurrentUser;  // Test
            return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
            //return RedirectToAction("View1");
        }

        public string CurrentUser
        {
            get
            {
                if (HttpContext.Session.GetString("CurrentUser") == null)
                    return "Ruth";//Default värde

                return Convert.ToString(JsonConvert.DeserializeObject(HttpContext.Session.GetString("CurrentUser")));
            }
            set
            {
                HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(value));
            }
        }
    }
}
