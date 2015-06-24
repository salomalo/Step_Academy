using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("okssanamel@gmail.com", ""), // from who
                EnableSsl = true
            };          
           // client.Send("okssanamel@gmail.com","okssanamel@gmail.com","test 007","hello world");
            client.Send("okssanamel@gmail.com", "denis.datsiuk@gmail.com", "-- 007 --", "hello world");
            MailMessage o = new MailMessage();
        }
    }
}
