using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagement.Business;
using ParkingManagement.Helper;
using ParkingManagement.Model;
using ParkingManagement.Utils;

namespace ParkingManagement.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [CustomFilterAttribute]
        public ActionResult Dashboard()
        {
            ViewBag.IsAuthorize = Convert.ToInt32(SessionUtil.GetSession().Type)==1;
            List<ParkingZoneModel> zonelist = new Service().AllParkingZone();

            // Store the list of countries in ViewBag
            ViewBag.zonelist = new SelectList(zonelist, "ParkingZoneID", "ParkingZoneTitle");
            return View();
        }

        public ActionResult FetchAllData()
        {
            List<ParkingSpaceShowModel> allspace = new Service().AllSpace();

            return Json(allspace, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult BookParkingSpace(string vehicleRegistrationNumber)
        {
            bool bookingResult = new Service().BookSpace(vehicleRegistrationNumber);

            return Json(new { success = bookingResult });
        }

        [HttpPost]
        public ActionResult FreeParkingSpace(string vehicleRegistrationNumber)
        {
            bool bookingResult = new Service().FreeSpace(vehicleRegistrationNumber);

            return Json(new { success = bookingResult });
        }

        [HttpPost]
        public ActionResult DeleteAllTransaction()
        {
            bool result = new Service().DeleteAllTransaction();

            return Json(new { success = result });
        }
    }
}