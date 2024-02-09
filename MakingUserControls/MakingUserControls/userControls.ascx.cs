using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakingUserControls
{
    public partial class userControls : System.Web.UI.UserControl
    {
        public string IdValue { get;set;}

        public string Name { get;set;}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // By default, sort by first column in ascending order
                ViewState["SortExpression"] = "id";
                ViewState["SortDirection"] = "ASC";
                BindGridView();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView(); // Call a method to rebind the GridView
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the StudentID of the row being deleted
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            // Delete the record from your data source using the studentID

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM [usernote] WHERE [id]=@id";
                cmd.Parameters.AddWithValue("@id", id); // You need to replace YourSelectedStudentID with the actual StudentID of the record you want to delete
                cmd.ExecuteNonQuery();
            }

            // Then rebind the GridView
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Get the StudentID of the row being updated
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            // Get updated values from the TextBoxes or other input controls within the row



            if (GridView1.Rows[e.RowIndex].FindControl("TextBox1") is TextBox noteTextBox)
            {
                // Get the values from the TextBoxes
                string note = noteTextBox.Text;

                // Update the record in your data source using the studentID and updated values
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE [usernote] SET [note]=@note WHERE [id]=@id";
                    cmd.Parameters.AddWithValue("@note", note);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Update Operation Was Successfull');</script>");
                }
                // Then rebind the GridView
            }
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView(); // Call a method to rebind the GridView
        }

        protected void InsertButton(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO usernote (note, noteid, notetype, datetimes) VALUES (@note, @noteid, @notetype, @datetime)";
                cmd.Parameters.AddWithValue("@note", Textarea1.Value);
                cmd.Parameters.AddWithValue("@noteid", IdValue);
                cmd.Parameters.AddWithValue("@notetype", Name);
                cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
                cmd.ExecuteNonQuery();
                Response.Write("Done!!");
            }
            Textarea1.Value = "";
            BindGridView();
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

            string query = $"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY [{sortExpression}] {sortDirection}) AS RowNum, * FROM [usernote] WHERE notetype=@notetype) AS Temp WHERE notetype=@notetype and RowNum BETWEEN @StartRowIndex AND @EndRowIndex";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StartRowIndex", startRowIndex);
                    cmd.Parameters.AddWithValue("@notetype", Name);
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
                cmd.CommandText = "SELECT COUNT(*) FROM usernote where notetype=@notetype;";
                cmd.Parameters.AddWithValue("@notetype", Name);
                totalCount = (int)cmd.ExecuteScalar();
            }
            return totalCount;
        }

    }
}