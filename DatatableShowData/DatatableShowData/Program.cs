using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatatableShowData
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Salary { get; set; }

        public Student(object id, object name, object email, object salary)
        {
            Id = (int) id;
            Name = (string) name;
            Email = (string) email;
            Salary = (string) salary;
        }

        public void ToString()
        {
            Console.WriteLine("Id " + Id + " Name " + Name + " Email " + Email + " Salary " + Salary);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                string query = "select * from student";
                SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
                
                DataTable dataTable = new DataTable();  
                conn.Open();
                adapter.Fill(dataTable);
                conn.Close();
                List<Student> students = new List<Student>();
                foreach(DataRow row in dataTable.Rows) 
                {
                    students.Add(new Student(row["id"], row["name"], row["email"], row["salary"]));
                }
                for(int i = 0; i < students.Count; i++)
                {
                    students[i].ToString();
                }
            }
            Console.ReadLine();
        }
    }
}
