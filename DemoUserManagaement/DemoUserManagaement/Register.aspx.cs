using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoUserManagaement.Business;
using DemoUserManagaement.Model;
using DemoUserManagaement.Utils;
using Newtonsoft.Json;

namespace DemoUserManagaement
{
    public partial class Register : System.Web.UI.Page
    {
        public static Service service = new Service();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CountryName> GetAllCountries()
        {
            return service.CountryNames();
        }

        [WebMethod]
        public static List<StateName> GetAllStates(int id)
        {
            return service.AllStates(id);
        }


        [WebMethod]
        public static bool UserSave(string jsonData)
        {
            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(jsonData);
            return service.UserSave(userInfo);
        }

        [WebMethod]
        public static bool FindEmail(int id, string email)
        {
            return service.FindEmail(id, email);
        }

        [WebMethod]
        public static UserInfo LoadUser(int id)
        {
            return service.UserGet(id);
        }
    }
}