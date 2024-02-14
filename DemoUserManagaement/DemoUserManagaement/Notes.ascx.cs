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
using DemoUserManagaement.Utils;

namespace DemoUserManagaement
{
    public partial class Notes : System.Web.UI.UserControl
    {

        Service service = new Service();
        public string IdValue { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // By default, sort by first column in ascending order
                ViewState["SortExpression"] = "NoteID";
                ViewState["SortDirection"] = "ASC";
                BindGridView();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView(); // Call a method to rebind the GridView
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView(); // Call a method to rebind the GridView
        }

        protected void InsertButton(object sender, EventArgs e)
        {
            try
            {
                NotesInfo n = new NotesInfo
                {
                    NoteText = Textarea1.Value,
                    ObjectID = Convert.ToInt32(IdValue),
                };
                service.NoteSave(n);
                Textarea1.Value = "";
                BindGridView();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void SortingGridView(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            string sortDirection = ViewState["SortDirection"].ToString();
            ViewState["SortExpression"] = sortExpression;
            ViewState["SortDirection"] = sortDirection == "ASC" ? "DESC" : "ASC";

            BindGridView();
        }



        private void BindGridView()
        {
            try
            {
                int currentPageIndex = GridView1.PageIndex;
                int pageSize = GridView1.PageSize;
                string sortExpression = ViewState["SortExpression"].ToString();
                string sortDirection = ViewState["SortDirection"].ToString();
                int totalCount = GetTotalCount(IdValue);

                GridView1.VirtualItemCount = totalCount;

                // Calculate start and end row indexes based on pagination
                int startRowIndex = (currentPageIndex * pageSize) + 1;
                int endRowIndex = startRowIndex + pageSize - 1;

                GridView1.DataSource = service.NotesInfos(sortExpression, sortDirection, currentPageIndex * pageSize, pageSize, Convert.ToInt32(IdValue));
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        private int GetTotalCount(String id)
        {
            int totalCount = 0;
            totalCount = service.LenNotes(Convert.ToInt32(id));
            return totalCount;
        }

    }
}