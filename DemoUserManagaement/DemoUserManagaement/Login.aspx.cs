using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoUserManagaement.Business;
using DemoUserManagaement.Model;
using Newtonsoft.Json;

namespace DemoUserManagaement
{
    public partial class Login : System.Web.UI.Page
    {
        public static Service DataAccess = new Service();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string UserLogin(string email, string password)
        {
            LoginModel l = new LoginModel
            {
                Email = email,
                Password = password
            };

            List<RoleModel> roles = DataAccess.LoginUser(l);

            if (roles !=null)
            {
                HttpContext.Current.Session["role"] = roles[0].Id;
            }

            if (roles!=null && roles.Count>0)
            {
                HttpContext.Current.Session["id"] = roles[0].UserId;
                return JsonConvert.SerializeObject(roles);
            }
            return string.Empty;
        }
    }
}