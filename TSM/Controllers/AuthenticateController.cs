using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSM.Models;

namespace TSM.Controllers
{
    public class AuthenticateController : Controller
    {


        // GET: Authenticate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authenticate/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Authenticate/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection collection)
        {
            string errormsg = "";
            try
            {
                //kolla om användaren är rätt
                MedlemDetail md = new MedlemDetail();
                int resultat = md.Register(collection, out errormsg);

                if(resultat == 1)
                {
                    //Successfull
                    return RedirectToAction("view1", "Auth");
                }
                else {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Authenticate/Login
        public ActionResult Login()
        {
            

               return RedirectToAction("View1","Auth");
            return View();

        }

        // GET: Authenticate/Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            
            return RedirectToAction("Index", "Auth");

        }
    }
}