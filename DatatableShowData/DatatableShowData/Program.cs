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
        public int id { get; set; }
        public string name { get; set; }
        public string email{ get; set; }
        public string salary { get; set; }

        public Student() { }    

        public Student(object id, object name, object email, object salary)
        {
            id = (int) id;
            name = (string) name;
            email = (string) email;
            salary = (string) salary;
        }

        public void ToString()
        {
            Console.WriteLine("Id " + id + " Name " + name + " Email " + email + " Salary " + salary);
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
                adapter.Fill(dataTable);
                List<Student> students = null;
                students = dataTable.toList<Student>();
                //foreach(DataRow row in dataTable.Rows) 
                //{
                //    students.Add(new Student(row["id"], row["name"], row["email"], row["salary"]));
                //}



                for(int i = 0; i < students.Count; i++)
                {
                    students[i].ToString();
                }
            }
            Console.ReadLine();
        }

        static List<T> ConvertList<T>(DataTable dataTable) where T : new()
        {
            List<T> newList= new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T t= new T();
                foreach(var property in typeof(T).GetProperties())
                {
                    if (dataTable.Columns.Contains(property.Name.ToLower()))
                    {
                        var value = Convert.ChangeType(row[property.Name], property.PropertyType);
                        property.SetValue(t, value);
                    }
                }
                newList.Add(t);
            }

            return newList;
        }

        
    }


    public static class Listify
    {
        public static List<T> toList<T>(this DataTable dataTable) where T : class, new()
        {
            List<T> newList = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T t = new T();
                foreach (var property in typeof(T).GetProperties())
                {
                    if (dataTable.Columns.Contains(property.Name.ToLower()))
                    {
                        var value = Convert.ChangeType(row[property.Name], property.PropertyType);
                        property.SetValue(t, value);
                    }
                }
                newList.Add(t);
            }

            return newList;
        }
    }
}
