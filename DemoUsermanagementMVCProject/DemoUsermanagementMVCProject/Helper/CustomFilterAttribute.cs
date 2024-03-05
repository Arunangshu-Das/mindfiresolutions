using DemoUserManagaement.Model;
using DemoUserManagaement.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DemoUsermanagementMVCProject.Helper
{
    public class CustomFilterAttribute : FilterAttribute, IAuthorizationFilter
    {
        private readonly string[] allowedRoles;

        public CustomFilterAttribute(params string[] roles)
        {
            allowedRoles = roles;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string pagename = filterContext.HttpContext.Request.Url.PathAndQuery.ToLower();
            if (pagename.Contains("/userlist2/index"))
            {
                if (!(Authinticate() && AuthorizeUser()))
                {
                    filterContext.Result = new RedirectResult("~/Login2/Index");
                }
            }
            else if (pagename.Contains("/userregistration2/index"))
            {
                string requestid = filterContext.RouteData.Values["id"] as string;
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
                        filterContext.Result = new RedirectResult("~/Login2/Index");
                    }
                }
                else if (session.UserInfo != null)
                {
                    filterContext.Result = new RedirectResult("~/UserRegistration2/EditUser/" + SessionUtil.GetSession().UserInfo.UserID);
                }
            }
            else if (pagename.Contains("login2/index"))
            {
                if (Authinticate())
                {
                    SessionClassModel session = SessionUtil.GetSession();
                    filterContext.Result = new RedirectResult("~/UserRegistration2/EditUser/" + SessionUtil.GetSession().UserInfo.UserID);
                }
            }
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
    }
}