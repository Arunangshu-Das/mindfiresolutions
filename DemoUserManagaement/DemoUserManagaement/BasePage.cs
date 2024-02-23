using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using DemoUserManagaement.Business;
using DemoUserManagaement.Model;
using Newtonsoft.Json;
using WebGrease.Css.Ast;
using DemoUserManagaement.Utils;
using System.IO;
using Microsoft.Ajax.Utilities;

namespace DemoUserManagaement
{
    public class BasePage : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string pagename = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
            if (string.Equals(pagename, "users", StringComparison.OrdinalIgnoreCase))
            {
                if (!(Authinticate() && AuthorizeUser()))
                {
                    Response.Redirect("~/login.aspx");
                }
            }
            if (string.Equals(pagename, "register", StringComparison.OrdinalIgnoreCase))
            {
                string requestid = Request.QueryString["id"];
                int id = 0;

                try
                {
                    id = Convert.ToInt32(requestid); ;
                }
                catch (Exception ex)
                {
                    id = 0;
                }

                SessionClassModel session = SessionUtil.GetSession();
                if (id != 0)
                {
                    bool flag = false;
                    if (session.UserInfo != null)
                    {
                        if (session.UserInfo.UserID == id)
                        {
                            flag = true;
                        }
                        else if (session.UserInfo.UserID != id)
                        {
                            foreach (RoleModel r in session.Roles)
                            {
                                if (r.Id == (int)Enums.ROLE.ADMIN)
                                {
                                    flag = true;
                                }
                            }
                        }
                    }

                    if (!flag)
                    {
                        Response.Redirect("~/login.aspx");
                    }
                }
                else if (session.UserInfo != null)
                {
                    Response.Redirect("~/register.aspx?id=" + session.UserInfo.UserID);
                }
            }
            else if (string.Equals(pagename, "login", StringComparison.OrdinalIgnoreCase))
            {
                if (Authinticate())
                {
                    SessionClassModel session = SessionUtil.GetSession();
                    Response.Redirect("~/Register.aspx?id=" + session.UserInfo.UserID);
                }
            }
            else if (pagename.ToLower() != "login" && !Authinticate())
            {
                Response.Redirect("login.aspx");
            }
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
            //SessionClassModel Obj = SessionUtil.GetSession();
            //if (Obj.UserInfo == null)
            //{
            //    return null;
            //}
            //if (Obj.UserInfo.UserID == id)
            //{
            //    return new DemoUserManagaement.Business.Service().UserGet(id);
            //}
            //else
            //{
            //    foreach (RoleModel r in Obj.Roles)
            //    {
            //        if (r.Id == 2)
            //        {
            //            return new DemoUserManagaement.Business.Service().UserGet(id);
            //        }
            //    }
            //}
            //return new DemoUserManagaement.Business.Service().UserGet(Obj.UserInfo.UserID);

            return new DemoUserManagaement.Business.Service().UserGet(id);
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
        public static string Login(string email, string password)
        {
            LoginModel l = new LoginModel
            {
                Email = email,
                Password = password
            };

            SessionClassModel roles = new DemoUserManagaement.Business.Service().LoginUser(l);

            if (roles != null)
            {
                SessionUtil.SetSession(roles);
                return JsonConvert.SerializeObject(roles.Roles);
            }
            return string.Empty;
        }

        public static bool Authinticate()
        {
            SessionClassModel session = SessionUtil.GetSession();
            if (session.Roles != null)
            {
                return true;
            }
            return false;
        }

        [WebMethod]
        public static bool SaveNotes(NotesInfo note)
        {
            bool flag = false;
            try
            {
                SessionClassModel Obj = SessionUtil.GetSession();
                new DemoUserManagaement.Business.Service().NoteSave(note);
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        protected bool AuthorizeUser()
        {
            bool flag = false;
            SessionClassModel Obj = SessionUtil.GetSession();
            if (Obj.Roles == null)
            {
                return false;
            }
            foreach (RoleModel r in Obj.Roles)
            {
                if (r.Id == 2)
                {
                    flag = true;
                }
            }
            //if (flag == false)
            //{
            //    Response.Redirect("~/login.aspx");
            //}
            return flag;
        }

        [WebMethod]
        public static bool DocumentSave(DocumentInfo Document)
        {
            SessionClassModel Obj = SessionUtil.GetSession();
            return new DemoUserManagaement.Business.Service().DocumentSave(Document);
        }

        [WebMethod]
        public static List<DocumentTypeModel> GetAllOptions()
        {
            return new DemoUserManagaement.Business.Service().DocumentTypeNames(1);
        }
    }
}