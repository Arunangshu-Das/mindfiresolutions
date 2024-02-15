using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace DemoUserManagaement
{
    /// <summary>
    /// Summary description for Download
    /// </summary>
    public class Download : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string file = ConfigurationManager.AppSettings["MyBasePath"] + context.Request.QueryString["file"];
            file = HttpUtility.UrlDecode(file);

            //file = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["myBasePath"] +file);

            if (!string.IsNullOrEmpty(file) && File.Exists(file))
            {
                string extension = Path.GetExtension(file).ToLower();
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    context.Response.ContentType = "image/jpeg";
                }
                else if (extension == ".pdf")
                {
                    context.Response.ContentType = "application/pdf";
                    context.Response.AddHeader("Content-Disposition", "inline; filename=\"" + Path.GetFileName(file) + "\"");
                }
                else
                {
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + Path.GetFileName(file) + "\"");
                }
                context.Response.WriteFile(file);
                //context.Response.End();
                context.ApplicationInstance.CompleteRequest();

            }
        }

        public void ProcessRequestOld(HttpContext context)
        {
            string file = ConfigurationManager.AppSettings["MyBasePath"] + context.Request.QueryString["file"];
            file = HttpUtility.UrlDecode(file);

            //file = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["myBasePath"] +file);

            if (!string.IsNullOrEmpty(file) && File.Exists(file))
            {
                string extension = Path.GetExtension(file).ToLower();

                // Set content type based on file extension
                //if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                //{
                //    context.Response.ContentType = "image/" + extension.Substring(1);
                //}
                //else if (extension == ".pdf")
                //{
                //    context.Response.ContentType = "application/pdf";
                //}
                //else
                //{
                //    // For other file types, you may customize the content type accordingly
                //    context.Response.ContentType = "application/octet-stream";
                //}

                // Remove content-disposition header to open the file in the browser
                //context.Response.ClearHeaders();
                context.Response.ContentType = "application/octet-stream";
                context.Response.AddHeader("content-disposition", "attachment;filename=" + Path.GetFileName(file));
                context.Response.WriteFile(file);

                //using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                //{
                //    byte[] buffer = new byte[4096];
                //    int bytesRead;

                //    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                //    {
                //        context.Response.OutputStream.Write(buffer, 0, bytesRead);
                //    }
                //}

                // This would be the ideal spot to collect some download statistics and / or tracking  
                // also, you could implement other requests, such as delete the file after download  
                context.Response.End();

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}