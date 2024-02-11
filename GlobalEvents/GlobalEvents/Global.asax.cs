using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace GlobalEvents
{
    public class Global : HttpApplication
    {

        void Application_Init(object sender, EventArgs e)
        {
            Response.Write("Init Completed!!!\n");
        }

        void Application_Disposed(object sender, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
            Response.Write("Application Error!!!\n");
        }

        void Application_End(object sender, EventArgs e)
        {
            Response.Write("Application End!!!\n");
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            Response.Write("Application BeginRequest!!!\n");
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            Response.Write("Application End!!!\n");
        }

        void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            Response.Write("Application Pre Request Handler Execute!!!\n");
        }

        void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            Response.Write("Application Post Request Handler Execute!!!\n");
        }

        void Applcation_PreSendRequestHeaders(object sender, EventArgs e)
        {
            Response.Write("Application Pre Send Request Headers!!!\n");
        }

        void Application_PreSendContent(object sender, EventArgs e)
        {
            Response.Write("Application Pre Send Content!!!\n");
        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            Response.Write("Application Acquire Request State!!!\n");
        }

        void Application_ReleaseRequestState(object sender, EventArgs e)
        {
            Response.Write("Application Release Request State\n");
        }

        void Application_ResolveRequestCache(object sender, EventArgs e)
        {
            Response.Write("Application Resolve Request Cache!!!\n");
        }

        void Application_UpdateRequestCache(object sender, EventArgs e)
        {
            Response.Write("Application Update Request Cache\n");
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            Response.Write("Application Authenticate Request!!!\n");
        }

        void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            Response.Write("Application Authorize Request\n");
        }

        void Session_Start(object sender, EventArgs e)
        {
            Response.Write("Session Start!!!\n");
        }

        void Session_End(object sender, EventArgs e)
        {
            Response.Write("Session End!!!\n");
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}