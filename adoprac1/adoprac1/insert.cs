using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoprac1
{
    internal class insert
    {
        public string InsertRecord()
        {
            String result = "";
            SqlConnection con = null;
            try
            {
                
                con = new SqlConnection("data source=.; database=practice; integrated security=SSPI");
              
                SqlCommand cm = new SqlCommand("insert into student (id, name, email, join_date) values ('101', 'Ronald Trump', 'ronald@example.com', '1/12/2017')", con);

               
                con.Open();
                
                cm.ExecuteNonQuery();
              
                result="Record Inserted Successfully";
            }
            catch (Exception e)
            {
                result="OOPs, something went wrong." + e;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

    }



}
