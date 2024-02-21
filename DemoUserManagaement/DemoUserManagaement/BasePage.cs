using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using DemoUserManagaement.Business;
using DemoUserManagaement.Model;
using Newtonsoft.Json;

namespace DemoUserManagaement
{
    public class BasePage : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static List<CountryName> GetAllCountries()
        {
            return new DemoUserManagaement.Business.Service().CountryNames();
        }

        [WebMethod]
        public static List<StateName> GetAllStates(int id)
        {
            return new DemoUserManagaement.Business.Service().AllStates(id);
        }

        [WebMethod(EnableSession = false)]
        public static UserInfo LoadUser(int id)
        {
            SessionClassModel Obj = (SessionClassModel)HttpContext.Current.Session["role"];
            if (Obj == null)
            {
                return null;
            }
            if (Obj.UserInfo.UserID == id)
            {
                return new DemoUserManagaement.Business.Service().UserGet(id);
            }
            else
            {
                foreach (RoleModel r in Obj.Roles)
                {
                    if (r.Id == 2)
                    {
                        return new DemoUserManagaement.Business.Service().UserGet(id);
                    }
                }
            }
            return new DemoUserManagaement.Business.Service().UserGet(Obj.UserInfo.UserID);
        }

        [WebMethod]
        public static bool UserUpdate(string jsonData)
        {
            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(jsonData);
            SessionClassModel Obj = (SessionClassModel)HttpContext.Current.Session["role"];
            if (Obj == null)
            {
                return false;
            }
            if (Obj.UserInfo.UserID == userInfo.UserID)
            {
                return new DemoUserManagaement.Business.Service().UserUpdate(userInfo);
            }
            else
            {
                foreach (RoleModel r in Obj.Roles)
                {
                    if (r.Id == 2)
                    {
                        return new DemoUserManagaement.Business.Service().UserUpdate(userInfo);
                    }
                }
            }
            userInfo.UserID = Obj.UserInfo.UserID;
            return new DemoUserManagaement.Business.Service().UserUpdate(userInfo);
        }

        [WebMethod]
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }


        [WebMethod]
        public static bool UserSave(string jsonData)
        {
            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(jsonData);
            return new DemoUserManagaement.Business.Service().UserSave(userInfo);
        }

        [WebMethod]
        public static bool FindEmail(int id, string email)
        {
            return new DemoUserManagaement.Business.Service().FindEmail(id, email);
        }

        [WebMethod]
        public static string UserLogin(string email, string password)
        {
            LoginModel l = new LoginModel
            {
                Email = email,
                Password = password
            };

            SessionClassModel roles = new DemoUserManagaement.Business.Service().LoginUser(l);

            if (roles != null)
            {
                HttpContext.Current.Session["role"] = roles;
                return JsonConvert.SerializeObject(roles.Roles);
            }
            return string.Empty;
        }

        [WebMethod]
        public static bool SaveNotes(string Text)
        {
            bool flag = false;
            try
            {
                NotesInfo note = new NotesInfo
                {
                    NoteText = Text,
                };
                SessionClassModel Obj = (SessionClassModel)HttpContext.Current.Session["role"];
                note.ObjectID = Obj.UserInfo.UserID;
                new DemoUserManagaement.Business.Service().NoteSave(note);
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
    }
}