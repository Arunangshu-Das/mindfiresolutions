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

namespace DemoUsermanagementMVCProject.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult _Notes(int objectId, int? page, string sortBy, string sortOrder)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ViewBag.PageSize = pageSize;
            ViewBag.ObjectId = objectId;
            List<NotesInfo> notes = new Service().NotesInfos(sortBy, sortOrder, pageNumber * pageSize, pageSize, objectId);
            var prevSortOrder = Request.QueryString["sortOrder"];

            ViewBag.SortBy = sortBy;
            ViewBag.SortOrder = prevSortOrder == "asc" ? "desc" : "asc";

            ViewBag.PageSize = pageSize;
            ViewBag.Notes = notes;
            return PartialView("_Notes", notes);
        }
    }
}