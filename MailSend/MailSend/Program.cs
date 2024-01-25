using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace MailSend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("c9aaf2b4589b0c", "54272606303edc"),
                EnableSsl = false
            };
            client.Send("arunangshud@mindfiresolutions.com", "sdasdsa@sadasd.com", "Hello world", "testbody");
            Console.WriteLine("Sent");
            Console.ReadLine();
        }
    }
}
