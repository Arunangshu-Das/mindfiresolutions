using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLinq
{
    public class Student
    {

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

    }

    public class Business
    {
        public string Name { get; set; }
        public int Stock { get; set; }
    }

    public class Details
    {
        public int cardId {  get; set; }
        public string cardType { get; set; }
        public int status { get; set; }
        public decimal totalAmt { get; set; }
    }

    internal class Program
    {
        public void Linq1()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 20 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var thenByResult = studentList.OrderByDescending(s => s.Age).ThenBy(s => s.StudentName);

            var thenByDescResult = studentList.OrderBy(s => s.StudentName).ThenByDescending(s => s.Age);

            Console.WriteLine("ThenBy:");

            foreach (var std in thenByResult)
            {
                Console.WriteLine("Name: {0}, Age:{1}", std.StudentName, std.Age);
            }

            Console.WriteLine("ThenByDescending:");

            foreach (var std in thenByDescResult)
                Console.WriteLine("Name: {0}, Age:{1}", std.StudentName, std.Age);

            var groupedResult = studentList.GroupBy(s => s.Age);

            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key);  //Each group has a key 

                foreach (Student s in ageGroup)  //Each group has a inner collection  
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }
        }

        public static void DisplayColumn()
        {
            using (var context = new testdbmicrosoftEntities())
            {

                context.Database.Log = s => Console.WriteLine(s);

                //IEnumerable<Product> allproducts = context.Products;



                IQueryable<Business> allproducts = (IQueryable<Business>)(from r in context.Products
                                                                          select new Business
                                                                          {
                                                                              Name = r.Name,
                                                                              Stock = r.SafetyStockLevel
                                                                          });


                var products = allproducts.Where(p => p.Stock >= 800 && p.Name.Contains("Metal"));

                foreach (var product in products)
                {
                    Console.WriteLine(product.Name + " " + product.Stock);
                }


            }
        }

        public static void DisplayRandomData()
        {
            using (var context = new testdbmicrosoftEntities())
            {
                IEnumerable<CreditCard> allCard = context.CreditCards;
                //foreach(var creditCard in allCard)
                //{
                //    //Console.WriteLine(creditCard.CardNumber+" "+creditCard.);
                //   Type type = creditCard.GetType();

                //   var propery= type.GetProperties();

                //    foreach(var property in propery)
                //    {
                //        Console.WriteLine(property.Name+" "+property.GetValue(creditCard));
                //    }
                //}
                Random rnd = new Random();
                allCard.Count();

                CreditCard creditCard = allCard.ElementAt(rnd.Next(19000));

                Type type = creditCard.GetType();

                var propery = type.GetProperties();

                foreach (var property in propery)
                {
                    Console.WriteLine(property.Name + " " + property.GetValue(creditCard));
                }

            }
        }

        static void Main(string[] args)
        {
            //DisplayColumn();

            using (var context = new testdbmicrosoftEntities())
            {
                IQueryable<CreditCard> allCard = context.CreditCards;
                IQueryable<SalesOrderHeader> OrderDetails= context.SalesOrderHeaders;

                context.Database.Log = s => Console.WriteLine(s);

                var innerjoins = allCard.SelectMany(card => card.SalesOrderHeaders, (card, header) => new { card, header })
                                        .Join(OrderDetails,
                                            result => result.header.SalesOrderID,
                                            header => header.SalesOrderID,
                                            (result, header) => new Details
                                            {
                                                cardId = result.card.CreditCardID,
                                                cardType = result.card.CardType,
                                                status = header.Status,
                                                totalAmt = header.TotalDue
                                            }
                                            );


                //var innerjoins1= allCard.Join(OrderDetails,
                //                card => card.SalesOrderHeaders.Select(header => header.SalesOrderID).FirstOrDefault(),
                //                header => header.SalesOrderID,
                //                (card,header)=> new Details
                //                {
                //                    cardId=card.CreditCardID,
                //                    cardType=card.CardType,
                //                    status=header.Status,
                //                    totalAmt=header.TotalDue
                //                }
                //                );

                //var innerjoins = from card in allCard
                //                 from header in card.SalesOrderHeaders
                //                 join orderDetail in OrderDetails on header.SalesOrderID equals orderDetail.SalesOrderID
                //                 select new Details
                //                 {
                //                     cardId = card.CreditCardID,
                //                     cardType = card.CardType,
                //                     status = header.Status,
                //                     totalAmt = orderDetail.TotalDue
                //                 };


                foreach (var inner in innerjoins)
                {
                    Console.WriteLine(inner.cardId+" "+inner.cardType+" "+inner.status+" "+inner.totalAmt);
                    break;
                }

            }




            Console.ReadLine();
        }
    }
}
