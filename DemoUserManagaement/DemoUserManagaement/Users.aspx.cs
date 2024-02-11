using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagaement
{
    public partial class Users : System.Web.UI.Page
    {
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
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView(); // Call a method to rebind the GridView
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

            if (sortExpression == ViewState["SortExpression"].ToString())
            {
                sortDirection = sortDirection == "ASC" ? "DESC" : "ASC";
            }
            else
            {
                sortDirection = "ASC";
            }

            // Save sort expression and direction to ViewState
            ViewState["SortExpression"] = sortExpression;
            ViewState["SortDirection"] = sortDirection;

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

            // Calculate start and end row indexes based on pagination
            int startRowIndex = (currentPageIndex * pageSize) + 1;
            int endRowIndex = startRowIndex + pageSize - 1;

            string query = $"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY [{sortExpression}] {sortDirection}) AS RowNum, * FROM [UserDetails]) AS Temp WHERE RowNum BETWEEN @StartRowIndex AND @EndRowIndex";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StartRowIndex", startRowIndex);
                    cmd.Parameters.AddWithValue("@EndRowIndex", endRowIndex);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        private int GetTotalCount()
        {
            int totalCount = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT COUNT(*) FROM UserDetails;";
                totalCount = (int)cmd.ExecuteScalar();
            }
            return totalCount;
        }
    }
}