using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace DemoUserManagaement
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            try
            {
                var file = context.Request.Files[0];
                string fileName = context.Request["name"]; // Retrieve the additional file name

                if (file != null && file.ContentLength > 0)
                {
                    if (string.IsNullOrEmpty(fileName)) 
                    {
                        // If no name is provided, generate a unique name or handle it as needed
                        fileName = Guid.NewGuid().ToString();
                    }

                    string fileExtension = Path.GetExtension(file.FileName);
                    fileName = fileName + fileExtension;

                    string uploadFolder = ConfigurationManager.AppSettings["MyBasePath"]; // Change this path as needed
                    string filePath = Path.Combine(uploadFolder, fileName);

                    file.SaveAs(filePath);

                    // You can perform additional processing here, such as resizing the image or storing additional information in a database.

                    // Return the URL of the saved image
                    string imageUrl = context.Request.Url.GetLeftPart(UriPartial.Authority) + "/uploads/" + fileName;
                    context.Response.Write(fileName);
                }
                else
                {
                    context.Response.Write("{\"error\": \"No file received.\"}");
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"error\": \"" + ex.Message + "\"}");
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