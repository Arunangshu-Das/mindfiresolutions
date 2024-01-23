using CRUDOperation.LOG;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperation.DAO
{
    public class Student :Base
    {
        /// <summary>
        /// Delete Data from Database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileName"></param>
        public void DeleteData(int id, String fileName)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = MakeConnection();
                // writing sql query  
                SqlCommand cm = new SqlCommand("delete from student where id = @id", con);

                cm.Parameters.AddWithValue("@id", id);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                Console.WriteLine("Record Deleted Successfully");
            }
            catch (Exception e)
            {
                logger.addData(e, fileName);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Display all data from Database
        /// </summary>
        /// <param name="fileName"></param>
        public void DisplayData(String fileName)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = MakeConnection();
                // writing sql query  
                SqlCommand cm = new SqlCommand("Select * from student", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                Console.WriteLine("id   name   email   salary");
                while (sdr.Read())
                {
                    // Displaying Record  
                    Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"] + " " + sdr["salary"]);
                }
            }
            catch (Exception e)
            {
                logger.addData(e, fileName);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Create table Student
        /// </summary>
        /// <param name="fileName"></param>
        public void CreateTable(String fileName)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = MakeConnection();
                // writing sql query  
                SqlCommand cm = new SqlCommand("IF  NOT EXISTS (SELECT * FROM sys.objects \r\nWHERE object_id = OBJECT_ID(N'[dbo].[student]') AND type in (N'U'))\r\n\r\nBEGIN \r\n\tcreate table student (id int primary key identity(1,1), name varchar(100), email varchar(50), salary varchar(50)) \r\nend", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                logger.addData(e, fileName);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Insert Record into Database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="salary"></param>
        /// <param name="fileName"></param>
        public void InsertRecord(String name, String email, String salary, String fileName)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = MakeConnection();
                // writing sql query  
                SqlCommand cm = new SqlCommand("insert into student (name, email, salary) values (@Name,@Email,@Salary)", con);

                cm.Parameters.AddWithValue("@Name", name);
                cm.Parameters.AddWithValue("@Email", email);
                cm.Parameters.AddWithValue("@Salary", salary);

                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record Inserted Successfully");
            }
            catch (Exception e)
            {
                logger.addData(e, fileName);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }
}
