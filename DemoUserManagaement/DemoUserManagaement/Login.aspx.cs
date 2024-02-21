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
    public partial class Login : BasePage
    {
        public static Service DataAccess = new Service();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}