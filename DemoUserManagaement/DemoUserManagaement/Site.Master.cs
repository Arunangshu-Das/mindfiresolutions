using DemoUserManagaement.Model;
using DemoUserManagaement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagaement
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Name.Text = MainContent.Page.Title;
            if (!IsPostBack)
            {
                GenerateNavigationLinks();
            }
        }

        private void GenerateNavigationLinks()
        {
            SessionClassModel session = SessionUtil.GetSession();
            if (session.UserInfo != null)
            {
                AddNavItem("Home", "~/");
                AddNavItem("About", "~/about.aspx");
                AddNavItem("Contact", "~/contact.aspx");
                if (session.Roles[0].Id == (int)Enums.ROLE.ADMIN)
                {
                    AddNavItem("All User", "~/users.aspx");
                }
                AddNavItem("New User", "~/register.aspx");
                AddNavItem("Logout", "~/logout.aspx");
            }
            else
            {
                AddNavItem("Home", "~/");
                AddNavItem("About", "~/about.aspx");
                AddNavItem("Contact", "~/contact.aspx");
                AddNavItem("User Details", "~/register.aspx");
                AddNavItem("Login", "~/login.aspx");
            }
        }

        private void AddNavItem(string text, string url)
        {
            var listItem = new ListItem();
            var link = new HyperLink();

            link.Text = text;
            link.NavigateUrl = url;
            link.ForeColor = System.Drawing.Color.White;

            navbarList.Controls.Add(link);
        }
    }
}