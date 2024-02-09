using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace practiceWebApp1
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        //private const string ASCENDING = " ASC";
        //private const string DESCENDING = " DESC";
        //private const int PageSize = 10;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        Bindgrid();
        //    }
        //}

        //private void Bindgrid()
        //{
        //    int pageIndex = GridView1.PageIndex;
        //    int startRowIndex = pageIndex * PageSize + 1;
        //    int endRowIndex = (pageIndex + 1) * PageSize;

        //    string query = "SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY CardNumber) AS RowNum, * FROM sales.creditcard) AS Temp WHERE RowNum BETWEEN @StartRowIndex AND @EndRowIndex";

        //    //string query = "select * from sales.creditcard";


        //    string connectionString = WebConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand com = new SqlCommand(query, con))
        //        {
        //            com.Parameters.AddWithValue("@StartRowIndex", startRowIndex);
        //            com.Parameters.AddWithValue("@EndRowIndex", endRowIndex);

        //            con.Open();
        //            SqlDataAdapter da = new SqlDataAdapter(com);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);

        //            ViewState["Paging"] = dt;
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //        }
        //    }
        //}

        //protected void Gridpaging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    Bindgrid();
        //}

        //protected void Gridsorting(object sender, GridViewSortEventArgs e)
        //{
        //    string columnToSort = e.SortExpression;
        //    SortDirection direction = GetSortDirection(columnToSort);
        //    SortGridView(columnToSort, direction);
        //}

        //private SortDirection GetSortDirection(string column)
        //{
        //    if (ViewState["SortColumn"] != null && ViewState["SortColumn"].ToString() == column)
        //    {
        //        if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
        //        {
        //            return SortDirection.Descending;
        //        }
        //        else
        //        {
        //            return SortDirection.Ascending;
        //        }
        //    }
        //    else
        //    {
        //        return SortDirection.Ascending;
        //    }
        //}

        //private void SortGridView(string sortExpression, SortDirection direction)
        //{
        //    DataTable dt = (DataTable)ViewState["Paging"];
        //    DataView dv = new DataView(dt);
        //    dv.Sort = sortExpression + (direction == SortDirection.Ascending ? ASCENDING : DESCENDING);

        //    GridView1.DataSource = dv;
        //    GridView1.DataBind();

        //    ViewState["SortColumn"] = sortExpression;
        //    ViewState["SortDirection"] = direction;
        //}



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // By default, sort by first column in ascending order
                ViewState["SortExpression"] = "StudentID";
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
            int studentID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            // Delete the record from your data source using the studentID

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM [Student] WHERE [StudentID]=@StudentID";
                cmd.Parameters.AddWithValue("@StudentID", studentID); // You need to replace YourSelectedStudentID with the actual StudentID of the record you want to delete
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Deletion Operation Was Successfull');</script>");
            }

            // Then rebind the GridView
            BindGridView();
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Get the StudentID of the row being updated
            int studentID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            // Get updated values from the TextBoxes or other input controls within the row



            if (GridView1.Rows[e.RowIndex].FindControl("TextBox1") is TextBox nameTextBox && GridView1.Rows[e.RowIndex].FindControl("TextBox2") is TextBox emailTextBox && GridView1.Rows[e.RowIndex].FindControl("TextBox3") is TextBox salaryTextBox)
            {
                // Get the values from the TextBoxes
                string name = nameTextBox.Text;
                string email = emailTextBox.Text;
                string salary = salaryTextBox.Text;

                // Update the record in your data source using the studentID and updated values
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE [Student] SET [name]=@name, [email]=@email, [salaryamt]=@salaryamt WHERE [StudentID]=@StudentID";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@salaryamt", salary);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
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
                cmd.CommandText = "INSERT INTO Student (name, email, salaryamt) VALUES (@name, @email, @salary)";
                cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@email", TextBox2.Text);
                cmd.Parameters.AddWithValue("@salary", TextBox3.Text);
                cmd.ExecuteNonQuery();
                Response.Write("Done!!");
            }
            BindGridView();
        }

        //protected void UpdateButton(object sender, EventArgs e)
        //{
        //    if (!int.TryParse(txtStudentIDToUpdate.Text, out int studentID))
        //    {
        //        Response.Write("<script>alert('Please Enter A valid StudentID to Update');</script>");
        //        return;
        //    }

        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
        //    {
        //        con.Open();
        //        SqlCommand cmd = con.CreateCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "UPDATE [Student] SET [name]=@name, [email]=@email, [salaryamt]=@salaryamt WHERE [StudentID]=@StudentID";
        //        cmd.Parameters.AddWithValue("@name", TextBox1.Text);
        //        cmd.Parameters.AddWithValue("@email", TextBox2.Text);
        //        cmd.Parameters.AddWithValue("@salaryamt", TextBox3.Text);
        //        cmd.Parameters.AddWithValue("@StudentID", studentID);
        //        cmd.ExecuteNonQuery();
        //        Response.Write("<script>alert('Update Operation Was Successfull');</script>");
        //    }
        //}

        //protected void DeleteButton(object sender, EventArgs e)
        //{
        //    if (!int.TryParse(txtStudentIDToDelete.Text, out int studentID))
        //    {
        //        Response.Write("<script>alert('Please Enter A valid StudentID to Delete');</script>");
        //        return;
        //    }
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
        //    {
        //        con.Open();
        //        SqlCommand cmd = con.CreateCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "DELETE FROM [Student] WHERE [StudentID]=@StudentID";
        //        cmd.Parameters.AddWithValue("@StudentID", studentID); // You need to replace YourSelectedStudentID with the actual StudentID of the record you want to delete
        //        cmd.ExecuteNonQuery();
        //        Response.Write("<script>alert('Deletion Operation Was Successfull');</script>");
        //    }

        //}

        protected void ResetButton(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            //txtStudentIDToUpdate.Text = "";
            //txtStudentIDToDelete.Text = "";
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

            string query = $"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY [{sortExpression}] {sortDirection}) AS RowNum, * FROM [Student]) AS Temp WHERE RowNum BETWEEN @StartRowIndex AND @EndRowIndex";

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
                cmd.CommandText = "SELECT COUNT(*) FROM Student;";
                totalCount = (int)cmd.ExecuteScalar();
            }
            return totalCount;
        }
    }
}