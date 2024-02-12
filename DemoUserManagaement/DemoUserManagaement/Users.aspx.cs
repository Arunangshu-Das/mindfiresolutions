using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoUserManagaement.Model;
using DemoUserManagaement.Business;

namespace DemoUserManagaement
{
    public partial class Users : System.Web.UI.Page
    {

        Service service = new Service();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // By default, sort by first column in ascending order
                ViewState["SortExpression"] = "UserID";
                ViewState["SortDirection"] = "ASC";
                BindGridView();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridView1.EditIndex = e.NewEditIndex;
            //BindGridView(); // Call a method to rebind the GridView
            Response.Redirect("UserDetails?id=" + GridView1.DataKeys[e.NewEditIndex].Values["UserID"]);

        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView(); // Call a method to rebind the GridView
        }


        protected void SortingGridView(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            string sortDirection = ViewState["SortDirection"].ToString();
            ViewState["SortExpression"] = sortExpression;
            ViewState["SortDirection"] = sortDirection == "ASC" ? "DESC" : "ASC";

            BindGridView();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        private void BindGridView()
        {
            int currentPageIndex = GridView1.PageIndex;
            int pageSize = GridView1.PageSize;
            string sortExpression = ViewState["SortExpression"].ToString();
            string sortDirection = ViewState["SortDirection"].ToString();
            int totalCount = GetTotalCount();

            GridView1.VirtualItemCount = totalCount;

            GridView1.DataSource = service.Allusers(sortExpression, sortDirection, currentPageIndex * pageSize, pageSize);
            GridView1.DataBind();
        }


        private int GetTotalCount()
        {
            int totalCount = 0;
            totalCount = service.Lenusers();
            return totalCount;
        }
    }
}