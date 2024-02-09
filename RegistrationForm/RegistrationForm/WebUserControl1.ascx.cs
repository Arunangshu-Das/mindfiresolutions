using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public string PageName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            hi.Text = PageName;
        }
    }
}