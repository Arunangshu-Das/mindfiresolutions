using DemoUserManagaement.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DemoUserManagaement.Utils.Enums;
using System.Web.UI;
using DemoUserManagaement.Business;
using DemoUserManagaement.Utils;

namespace DemoUsermanagementMVCProject.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult _Notes(int objectId, int? page, string sortBy, string sortOrder)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 0);

            ViewBag.NotesPageSize = pageSize;
            ViewBag.NotesObjectId = objectId;
            List<NotesInfo> notes = new Service().NotesInfos(sortBy, sortOrder, pageNumber * pageSize, pageSize, objectId);
            var prevSortOrder = Request.QueryString["sortOrder"];

            ViewBag.NotesSortBy = sortBy;
            ViewBag.NotesSortOrder = prevSortOrder == "asc" ? "desc" : "asc";

            ViewBag.NotesPageSize = pageSize;
            ViewBag.Notes = notes;
            return PartialView("_Notes", notes);
        }

        [HttpPost]
        public ActionResult SaveNotes(NotesInfo note)
        {
            bool flag = false;

            try
            {
                SessionClassModel Obj = SessionUtil.GetSession();
                new DemoUserManagaement.Business.Service().NoteSave(note);
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }

            // Return an appropriate response, such as JSON
            return Json(new { success = flag });
        }
    }
}