using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoprac1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // new Program().CreateTable();
            Console.WriteLine(new insert().InsertRecord());

            Console.ReadLine();
        }
        public void CreateTable()
        {
            SqlConnection con = null;
            try
            { 
                con = new SqlConnection("data source=.; database=practice; integrated security=SSPI");
                
                SqlCommand cm = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50), join_date date)", con);
                 
                con.Open();
                  
                cm.ExecuteNonQuery();
                
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
