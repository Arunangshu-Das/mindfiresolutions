using ParkingManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.Business;
using ParkingManagement.Helper;

namespace ParkingManagement.Controllers
{
    public class AddParkingController : Controller
    {
        // GET: AddParking
        [CustomFilterAttribute]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InitializeParkingData(ParkingModel model)
        {
            try
            {
                bool data = new Service().AddParkingSpace(model);
                if (data == true)
                {
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {

            }

            return View(model);
        }
    }
}