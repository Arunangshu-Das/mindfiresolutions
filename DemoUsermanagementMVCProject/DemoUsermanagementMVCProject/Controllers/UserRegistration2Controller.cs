using DemoUserManagaement.Model;
using DemoUserManagaement.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DemoUsermanagementMVCProject.Controllers
{
    public class UserRegistration2Controller : Controller
    {
        // GET: UserRegistration2
        public ActionResult Index()
        {
            List<CountryName> countries = new DemoUserManagaement.Business.Service().CountryNames();

            // Store the list of countries in ViewBag
            ViewBag.CountryList = new SelectList(countries, "CountryId", "CountryNames");
            return View();
        }

        [HttpPost]
        public JsonResult GetAllStates(int countryId)
        {
            List<StateName> states = new DemoUserManagaement.Business.Service().AllStates(countryId);
            return Json(states, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UserSave(UserInfo userinfo,HttpPostedFileBase fileImage, HttpPostedFileBase fileAadharCard, HttpPostedFileBase fileResume)
        {
            try
            {
                var uploadResult = HandleFileUpload(fileImage);
                userinfo.GuidProfilePhoto = uploadResult;
                userinfo.ProfilePhoto = Path.GetFileName(fileImage.FileName);
                uploadResult = HandleFileUpload(fileAadharCard);
                userinfo.GuidAadharcard = uploadResult;
                userinfo.Aadharcard = Path.GetFileName(fileAadharCard.FileName);
                uploadResult = HandleFileUpload(fileResume);
                userinfo.GuidMyResume = uploadResult;
                userinfo.MyResume = Path.GetFileName(fileResume.FileName);
                new DemoUserManagaement.Business.Service().UserSave(userinfo);
                
            }
            catch(Exception ex)
            {
                Logger.AddData(ex);
            }

            return View(userinfo);

        }

        private string HandleFileUpload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                    string uploadPath = Path.Combine(Server.MapPath("~/Uploads"), uniqueFileName);

                    file.SaveAs(uploadPath);
                    return uniqueFileName;
                }
                catch (Exception ex)
                {
                    Logger.AddData(ex);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}