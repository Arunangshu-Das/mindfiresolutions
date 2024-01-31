using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleCrudLayerWise.Utils
{
    public class Base
    {
        /// <summary>
        /// Make Connection with SQL Database
        /// </summary>
        /// <returns>SQLConnection</returns>
        public static SqlConnection MakeConnection()
        {
            String connection =
    System.Configuration.ConfigurationManager.
    ConnectionStrings["Test"].ConnectionString;
            return new SqlConnection(connection);
        }
    }
}
