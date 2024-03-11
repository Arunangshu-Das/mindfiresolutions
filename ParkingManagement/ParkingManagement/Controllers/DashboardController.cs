using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ParkingManagement.Business;
using ParkingManagement.Helper;
using ParkingManagement.Model;
using ParkingManagement.Utils;
using static ParkingManagement.Utils.Enums;

namespace ParkingManagement.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [CustomFilterAttribute]
        public ActionResult Dashboard()
        {
            ViewBag.IsAuthorize = Convert.ToInt32(SessionUtil.GetSession().Type)== (int)ADDRESS.BOOKING_COUNTER_AGENT;
            List<ParkingZoneModel> zonelist = new ParkingManagement.Business.Service().AllParkingZone();

            ViewBag.ZoneList = new SelectList(zonelist, "ParkingZoneID", "ParkingZoneTitle");
            return View();
        }

        public ActionResult FetchAllData()
        {
            List<ParkingSpaceShowModel> allspace = new ParkingManagement.Business.Service().AllParkingSpace();

            return Json(allspace, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult BookParkingSpace(string vehicleRegistrationNumber)
        {
            bool bookingResult = new ParkingManagement.Business.Service().BookSpace(vehicleRegistrationNumber);

            return Json(new { success = bookingResult });
        }

        [HttpPost]
        public ActionResult FreeParkingSpace(string vehicleRegistrationNumber)
        {
            bool bookingResult = new ParkingManagement.Business.Service().FreeSpace(vehicleRegistrationNumber);

            return Json(new { success = bookingResult });
        }

        [HttpPost]
        public ActionResult DeleteAllTransaction()
        {
            bool result = new ParkingManagement.Business.Service().DeleteAllTransaction();

            return Json(new { success = result });
        }
    }
}