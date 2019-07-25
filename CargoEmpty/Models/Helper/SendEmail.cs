using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace CargoEmpty.Models.Helper
{
    public static class SendEmail
    {
        public static void SendNewMail(string _To,string _Message,string _Subject)
        {

            Task.Run(() =>
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                MailAddress from = new MailAddress("kenanbagirov14@gmail.com", "CargoEmpty");
                client.EnableSsl = true;
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("kenanbagirov14@gmail.com", "kenan5952595");

                MailAddress to = new MailAddress(_To);

                MailMessage message = new MailMessage(from, to);
                message.Body = _Message;
                message.Subject = _Subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                ///  client.SendCompleted += new SendCompletedEventHandler(SentCompletedCallback);

                client.Send(message);
                message.Dispose();

            });
        }

        public static bool SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
                return false;
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
                return false;
            }
            else
            {
                Console.WriteLine("Message sent.");
                return true;
            }
         
        }
    }

  
}