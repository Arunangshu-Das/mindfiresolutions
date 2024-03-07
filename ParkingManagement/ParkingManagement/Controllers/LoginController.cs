using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.Model;
using ParkingManagement.Utils;
using ParkingManagement.Business;
using System.Reflection;

namespace ParkingManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            try
            {
                SessionModel session = new Service().Login(login);
                if (session != null)
                {
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception ex)
            {

            }
            
            return View(login);
        }
    }
}