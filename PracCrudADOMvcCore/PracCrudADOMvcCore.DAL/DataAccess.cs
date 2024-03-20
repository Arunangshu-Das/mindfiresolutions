using PracCrudADOMvcCore.Models;
using System.Xml.Linq;

namespace PracCrudADOMvcCore.DAL
{
    public class DataAccess : IDataAccess
    {
        private readonly string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool AddData(StudentModel s)
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

        public bool DeleteData(StudentModel s)
        {
            throw new NotImplementedException();
        }

        public List<StudentModel> ListData()
        {
            throw new NotImplementedException();
        }

        public bool UpdateData(StudentModel s)
        {
            throw new NotImplementedException();
        }
    }
}
