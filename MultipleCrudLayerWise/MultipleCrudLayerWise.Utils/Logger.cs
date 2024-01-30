﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleCrudLayerWise.Utils
{
    public class Logger
    {
        public static void AddData(Exception inputData)
        {
            String fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string file = ConfigurationManager.AppSettings["LogFileFolderPath"];
            file = file + "\\" + fileName;
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(inputData);
            }
            Console.WriteLine(inputData);
        }
    }
}
