using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUserManagaement.Business;
using DemoUsermanagementMVCProject.Helper;

namespace DemoUsermanagementMVCProject.Controllers
{
    [CustomFilter("Admin")]
    public class UserList2Controller : Controller
    {
        // GET: UserList2
        public ActionResult Index(string Order, string Direction, int? Page)
        {
            int pageno= (Page ?? 1);
            int size = 2;
            int allUsers = new Service().Lenusers();
            int pages= Convert.ToInt32(Math.Ceiling(allUsers/(double)size));

            int start = (pageno - 1) * size;

            int startIndex = (pageno - 1) * size;

            if(string.IsNullOrEmpty(Order))
            {
                Order = "UserID";
                Direction = "asc";
            }

            var userDetails= new Service().Allusers(Order,Direction,start,size);

            ViewBag.CurrentSortDir = Direction;
            ViewBag.PageSize = size;
            ViewBag.CurrentSort = Order;
            ViewBag.TotalPages = pages;

            return View(userDetails);
        }
    }
}