using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DemoUserManagaement.Utils
{
    public class Logger
    {
        public static void AddData(Exception inputData)
        {
            String fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            try
            {
                string file = ConfigurationManager.AppSettings["LogFileFolderPath"];
                file = file + "\\" + fileName;
                using (StreamWriter writer = new StreamWriter(file, true))
                {
                    writer.WriteLine(inputData.ToString());
                }
            }
            catch (Exception ex) 
            {
            }

        }
    }
}
