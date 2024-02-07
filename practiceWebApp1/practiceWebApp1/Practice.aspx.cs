using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practiceWebApp1
{
    public partial class Practice : System.Web.UI.Page
    {
        public void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ShowDate.Text = "You Selected: " + Calendar1.SelectedDate.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCourses.Text = "None";
            if (Request.Cookies["computer"].Values.ToString() != null)
            {
                if (Request.Cookies["computer"]["apple"] != null)
                    Label2.Text += Request.Cookies["computer"]["apple"] + " ";
                if (Request.Cookies["computer"]["dell"] != null)
                    Label2.Text += Request.Cookies["computer"]["dell"] + " ";
                if (Request.Cookies["computer"]["lenevo"] != null)
                    Label2.Text += Request.Cookies["computer"]["lenevo"] + " ";
                if (Request.Cookies["computer"]["acer"] != null)
                    Label2.Text += Request.Cookies["computer"]["acer"] + " ";
                if (Request.Cookies["computer"]["sony"] != null)
                    Label2.Text += Request.Cookies["computer"]["sony"] + " ";
                if (Request.Cookies["computer"]["wipro"] != null)
                    Label2.Text += Request.Cookies["computer"]["wipro"] + " ";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String k = RadioButton1.Checked ? RadioButton1.Text.ToString() : RadioButton2.Text.ToString();
            Label1.Text = "Your gender is " + k;
            var message = "";
            if (CheckBox1.Checked)
            {
                message = CheckBox1.Text + " ";
            }
            if (CheckBox2.Checked)
            {
                message += CheckBox2.Text + " ";
            }
            if (CheckBox3.Checked)
            {
                message += CheckBox3.Text;
            }
            ShowCourses.Text = message;

            //if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            //{
            //    string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            //    string SaveLocation = Server.MapPath("upload") + "\\" + fn;
            //    try
            //    {
            //        FileUpload1.PostedFile.SaveAs(SaveLocation);
            //        FileUploadStatus.Text = "The file has been uploaded.";
            //        Response.Write("HelloJI");
            //    }
            //    catch (Exception ex)
            //    {
            //        FileUploadStatus.Text = "Error: " + ex.Message;
            //    }
            //}
            //else
            //{
            //    FileUploadStatus.Text = "Please select a non-empty file to upload.";
            //    Response.Write("HelloJii");
            //}

            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                var count = 0;
                foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                {
                    string fn = System.IO.Path.GetFileName(uploadedFile.FileName);
                    string SaveLocation = Server.MapPath("upload") + "\\" + fn;
                    try
                    {
                        uploadedFile.SaveAs(SaveLocation);
                        count++;
                    }
                    catch (Exception ex)
                    {
                        FileUploadStatus.Text = "Error: " + ex.Message;
                    }
                }
                if (count > 0)
                {
                    FileUploadStatus.Text = count + " files has been uploaded.";
                }
            }
            else
            {
                FileUploadStatus.Text = "Please select a file to upload.";
            }
            //var filePath = "C:\\Users\\arunangshud\\Desktop\\e1.txt";
            //FileInfo file = new FileInfo(filePath);
            //if (file.Exists)
            //{
            //    // Clear Rsponse reference  
            //    Response.Clear();
            //    // Add header by specifying file name  
            //    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            //    // Add header for content length  
            //    Response.AddHeader("Content-Length", file.Length.ToString());
            //    // Specify content type  
            //    Response.ContentType = "text/plain";
            //    // Clearing flush  
            //    Response.Flush();
            //    // Transimiting file  
            //    Response.TransmitFile(file.FullName);
            //    Response.End();
            //}
            //else
            //{
            //    Label1.Text = "Requested file is not available to download";
            //}

            Label2.Text = "";
            // --------------- Adding Coockies ---------------------//  
            if (apple.Checked)
                Response.Cookies["computer"]["apple"] = "Apple";
            if (dell.Checked)
                Response.Cookies["computer"]["dell"] = "Dell";
            if (lenevo.Checked)
                Response.Cookies["computer"]["lenevo"] = "Lenevo";
            if (acer.Checked)
                Response.Cookies["computer"]["acer"] = "Acer";
            if (sony.Checked)
            {
                Session["computer"] = "Sony";
                Response.Cookies["computer"]["sony"] = "Sony";
            }
            if (wipro.Checked)
                Response.Cookies["computer"]["wipro"] = "Wipro";
            // --------------- Fetching Cookies -----------------------//  
            if (Request.Cookies["computer"].Values.ToString() != null)
            {
                if (Request.Cookies["computer"]["apple"] != null)
                    Label2.Text += Request.Cookies["computer"]["apple"] + " ";
                if (Request.Cookies["computer"]["dell"] != null)
                    Label2.Text += Request.Cookies["computer"]["dell"] + " ";
                if (Request.Cookies["computer"]["lenevo"] != null)
                    Label2.Text += Request.Cookies["computer"]["lenevo"] + " ";
                if (Request.Cookies["computer"]["acer"] != null)
                    Label2.Text += Request.Cookies["computer"]["acer"] + " ";
                if (Request.Cookies["computer"]["sony"] != null)
                    Label2.Text += Request.Cookies["computer"]["sony"] + " ";
                if (Request.Cookies["computer"]["wipro"] != null)
                    Label2.Text += Request.Cookies["computer"]["wipro"] + " ";
            }
            else Label2.Text = "Please select your choice";
            Response.Cookies["computer"].Expires = DateTime.Now.AddDays(10);
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Label2.Text = "Welcome to the javatpoint";
        }
    }
}