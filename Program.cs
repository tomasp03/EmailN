using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace EmailN
{

    class Program
    {
        static void Main(string[] args)
        {
            string sender = "tomasp0303@gmail.com";
            string recipient = "tomas.p03@seznam.cz";
            // Set up email message
            MailMessage message = new MailMessage();
            message.From = new MailAddress(sender);
            message.To.Add(recipient);
            message.Subject = "Pepa Z Depa";
            message.Body = "Mas Maly penis";

            // Add attachment
            Attachment attachment = new Attachment("C:\\Users\\tomas\\Documents\\Norsko\\CV\\Tomáš_Prusenovský_CV.pdf");
            message.Attachments.Add(attachment);

            // Set up SMTP client
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(sender, "password");
            client.EnableSsl = true;

            // Send email
            try
            {
                client.Send(message);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }

            Console.ReadLine();
        }
    }

}
