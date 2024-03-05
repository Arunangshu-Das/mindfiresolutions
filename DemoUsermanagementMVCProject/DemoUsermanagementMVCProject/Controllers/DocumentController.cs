using DemoUserManagaement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUserManagaement.Business;
using DemoUserManagaement.Utils;
using System.IO;

namespace DemoUsermanagementMVCProject.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult _Documents(int objectId, int? page, string sortBy, string sortOrder)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 0);

            ViewBag.DocumentsPageSize = pageSize;
            ViewBag.DocumentsObjectId = objectId;
            List<DocumentInfo> documents = new Service().DocumentsInfos(sortBy, sortOrder, pageNumber * pageSize, pageSize, objectId);
            var prevSortOrder = Request.QueryString["sortOrder"];

            ViewBag.DocumentsSortBy = sortBy;
            ViewBag.DocumentsSortOrder = prevSortOrder == "asc" ? "desc" : "asc";

            ViewBag.DocumentsPageSize = pageSize;
            ViewBag.Documents = documents;
            return PartialView("_Documents", documents);
        }

        [HttpPost]
        public ActionResult SaveDocs(HttpPostedFileBase file, string documenttype, int id)
        {
            bool flag = false;

            string filename=HandleFileUpload(file);

            DocumentInfo doc=new DocumentInfo
            {
                ObjectID = id,
                DocumentType = Convert.ToInt32(documenttype),
                ObjectType = 1,
                DocumentOriginalName = Path.GetFileName(file.FileName),
                DocumentGuidName= Path.GetFileName(filename),
            };

            try
            {
                SessionClassModel Obj = SessionUtil.GetSession();
                new DemoUserManagaement.Business.Service().DocumentSave(doc);
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }

            // Return an appropriate response, such as JSON
            return Json(new { success = flag });
        }

        private string HandleFileUpload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                    string uploadPath = Path.Combine(Server.MapPath("~/Uploads"), uniqueFileName);

                    file.SaveAs(uploadPath);
                    return uniqueFileName;
                }
                catch (Exception ex)
                {
                    Logger.AddData(ex);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}