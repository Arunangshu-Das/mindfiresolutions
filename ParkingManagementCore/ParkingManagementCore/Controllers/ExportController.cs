using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Business;

namespace ParkingManagement.Controllers
{
    //[CustomFilterAttribute]
    public class ExportController : Controller
    {
        // GET: Export
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Export(DateTime startDate, DateTime endDate)
        {
            var result = new Service().GenerateParkingReport(startDate, endDate);
            return Json(result);
        }
    }
}