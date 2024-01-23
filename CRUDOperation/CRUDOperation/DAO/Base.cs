using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.DAO
{
    public class Base
    {
        public static SqlConnection MakeConnection()
        {
            String connection =
    System.Configuration.ConfigurationManager.
    ConnectionStrings["Test"].ConnectionString;
            return new SqlConnection(connection);
        }
    }
}
