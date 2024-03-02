using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        public ActionResult Index()
        {
            return View();
        }


        public string Welcome(string name)
        {
            return "You selected " + name + " Music";
        }

        [Route("Music/test1")]
        [Route("Music/test2")]
        [Route("Music/test4")]
        [ActionName("store")]
        public ActionResult About()
        {
            return View();
        }
    }
}