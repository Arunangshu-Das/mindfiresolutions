using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practiceWebApp1
{
    public partial class ViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Value of TextBox1 and TextBox2 is assigned to the ViewState
            ViewState["name"] = TextBox1.Text;
            ViewState["password"] = TextBox2.Text;

            // After clicking on Button, TextBox value will be cleared
            TextBox1.Text = TextBox2.Text = string.Empty;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // If ViewState values are not null, assign them to TextBoxes
            if (ViewState["name"] != null)
            {
                TextBox1.Text = ViewState["name"].ToString();
            }

            if (ViewState["password"] != null)
            {
                TextBox2.Text = ViewState["password"].ToString();
            }
        }
    }
}