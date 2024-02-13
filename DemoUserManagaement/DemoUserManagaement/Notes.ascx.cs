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

        public string Name { get; set; }

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

        //protected void SortingGridView(object sender, GridViewSortEventArgs e)
        //{
        //    string sortExpression = e.SortExpression;
        //    string sortDirection = ViewState["SortDirection"].ToString();

        //    if (sortExpression == ViewState["SortExpression"].ToString())
        //    {
        //        sortDirection = sortDirection == "ASC" ? "DESC" : "ASC";
        //    }
        //    else
        //    {
        //        sortDirection = "ASC";
        //    }

        //    // Save sort expression and direction to ViewState
        //    ViewState["SortExpression"] = sortExpression;
        //    ViewState["SortDirection"] = sortDirection;

        //    BindGridView();
        //}

        

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