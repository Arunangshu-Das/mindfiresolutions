using DemoUserManagaement.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUserManagaement.Business;
using System.Web.Services;

namespace DemoUsermanagementMVCProject.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UserSave(string jsonData)
        {
            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(jsonData);
            bool result = new DemoUserManagaement.Business.Service().UserSave(userInfo);
            return Json(new { success = result });
        }

        [HttpPost]
        public JsonResult GetAllCountries()
        {
            List<CountryName> countries = new DemoUserManagaement.Business.Service().CountryNames();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public List<StateName> GetAllStates(int id)
        {
            return new DemoUserManagaement.Business.Service().AllStates(id);
        }

    }
}