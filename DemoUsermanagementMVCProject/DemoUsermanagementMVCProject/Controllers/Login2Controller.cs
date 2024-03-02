using DemoUserManagaement.Model;
using DemoUserManagaement.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUsermanagementMVCProject.Controllers
{
    public class Login2Controller : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            SessionClassModel roles = new DemoUserManagaement.Business.Service().LoginUser(model);

            if (roles != null)
            {
                SessionUtil.SetSession(roles);
                
            }
            return View(model);
        }
    }
}