using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace ParkingManagement.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Logout()
        {
            SessionUtil.ClearSession();
            return RedirectToAction("Index", "Login");
        }
    }
}