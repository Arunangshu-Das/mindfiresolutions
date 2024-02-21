using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoUserManagaement.Business;
using DemoUserManagaement.Utils;
using DemoUserManagaement.Model;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;
using System.Web.Services;

namespace DemoUserManagaement
{
    public partial class Document : System.Web.UI.UserControl
    {
        public static Service service = new Service();
        public string IdValue { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // By default, sort by first column in ascending order
                ViewState["SortExpression"] = "DocumentID";
                ViewState["SortDirection"] = "ASC";
                BindGridView();
                //List<DocumentTypeModel> documentTypes= service.DocumentTypeNames(1);
                //ddlSelectDocumentTypeFor.DataSource = documentTypes;
                //ddlSelectDocumentTypeFor.DataValueField = "Id"; // Property of your State class representing the value
                //ddlSelectDocumentTypeFor.DataTextField = "Name";
                //ddlSelectDocumentTypeFor.DataBind();
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

        //protected void InsertButton(object sender, EventArgs e)
        //{
        //    try
        //    {


        //        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
        //        {
        //            foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
        //            {
        //                Guid obj = Guid.NewGuid();
        //                string fn = System.IO.Path.GetFileName(uploadedFile.FileName);
        //                string fileImageLocation = ConfigurationManager.AppSettings["MyBasePath"] + "\\" + fn;
        //                string guidFileImageLocation = ConfigurationManager.AppSettings["MyBasePath"] + "\\" + obj.ToString() + Path.GetExtension(uploadedFile.FileName);
        //                try
        //                {
        //                    uploadedFile.SaveAs(guidFileImageLocation);
        //                }
        //                catch (Exception ex)
        //                {
        //                    Logger.AddData(ex);
        //                }

        //                DocumentInfo documentInfo = new DocumentInfo
        //                {
        //                    DocumentGuidName = Path.GetFileName(guidFileImageLocation),
        //                    DocumentOriginalName = Path.GetFileName(fileImageLocation),
        //                    ObjectID = Convert.ToInt32(IdValue),
        //                    DocumentType = Convert.ToInt32(ddlSelectDocumentTypeFor.SelectedValue),
        //                };
        //                service.DocumentSave(documentInfo);
        //            }
        //        }
        //        BindGridView();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.AddData(ex);
        //    }
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

                GridView1.DataSource = service.DocumentsInfos(sortExpression, sortDirection, currentPageIndex * pageSize, pageSize, Convert.ToInt32(IdValue));
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
            totalCount = service.LenDocs(Convert.ToInt32(id));
            return totalCount;
        }

    }
}