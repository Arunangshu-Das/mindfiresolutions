using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DemoUserManagaement.Model;

namespace DemoUserManagaement.Utils
{
    public class SessionUtil
    {
        public static SessionClassModel GetSession()
        {
            SessionClassModel Obj = HttpContext.Current.Session["role"] as SessionClassModel;
            return Obj!=null ? Obj : new SessionClassModel();
        }

        public static void SetSession(SessionClassModel session)
        {
            HttpContext.Current.Session["role"] = session;
        }
    }
}
