using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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

        public Student(int id, String name, String email, String salary)
        {
            id = id;
            name = name;
            email = email;
            salary = salary;
        }

        //public Student(object id, object name, object email, object salary)
        //{
        //    id = (int) id;
        //    name = (string) name;
        //    email = (string) email;
        //    salary = (string) salary;
        ////}

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
                students = dataTable.ToList<Student>();
                foreach (var item in students)
                {
                    item.ToString();
                }

                List<Student> student=new List<Student>();
                Student s1 = new Student(1, "hi", "hk", "90");
                Student s2 = new Student(2, "hij", "kk", "80");
                Student s3 = new Student(3, "pi", "wk", "190");
                student.Add(s1);
                student.Add(s2);
                student.Add(s3);
                DataTable dt = student.ToDataTable();

                Console.WriteLine("\n\n\n\n");
                
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["id"]+" "+row["name"]+" "+ row["email"]+" "+ row["salary"]);
                }
            }
            Console.ReadLine();
        }

        static List<T> ConvertList<T>(DataTable dataTable) where T : new()
        {
            List<T> newList= new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T t = new T();
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
        public static List<T> ToList<T>(this DataTable dataTable) where T : class, new()
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

        public static DataTable ToDataTable<T>(this List<T> list) where T : class, new()
        {
            DataTable dt = new DataTable();

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dt.Columns.Add(prop.Name);
            }

            foreach (T item in list)
            {
                DataRow values = dt.NewRow();
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }

            return dt;
        }
    }
}
