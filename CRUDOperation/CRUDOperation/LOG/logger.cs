using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.LOG
{
    internal class logger
    {
        public static void addData(Exception inputData, String fileName)
        {
            string file= ConfigurationManager.AppSettings["LogFileFolderPath"];
            file=file+"\\"+fileName;
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(inputData);
            }
        }
    }
}
