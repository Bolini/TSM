using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TSM.Models;

namespace TSM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Settings()
        {
            ViewData["CurrentUser"] = CurrentUser;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
