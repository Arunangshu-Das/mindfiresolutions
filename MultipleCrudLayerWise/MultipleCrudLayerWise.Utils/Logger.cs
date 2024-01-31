using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultipleCrudLayerWise.Utils
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
                    writer.WriteLine(inputData);
                }
                Console.WriteLine(inputData);
                SqlConnection con = null;
                con = Base.MakeConnection();
                // writing sql query  
                SqlCommand cm = new SqlCommand("insert into logtable (LogName, Date) values (@log,@date)", con);

                cm.Parameters.AddWithValue("@log", inputData.Message);
                cm.Parameters.AddWithValue("@date", DateTime.Now);

                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
