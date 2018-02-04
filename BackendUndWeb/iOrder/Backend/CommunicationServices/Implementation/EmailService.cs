using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.CommunicationServices.Implementation
{
    public class EmailService : ICommunicationService
    {
        private static string EMAIL_SMTP_SERVER = "smtp.gmail.com";
        private static string USERNAME = "iorder.orderingservice";
        private static string PASSWORD = "Iorder123456";
        private static string EMAIL_ADDRESS = "iorder.orderingservice@gmail.com";
        private static int PORT = 587;
        private SmtpClient _smtpClient;
        private SmtpClient Client
        {
            get
            {
                if (null == _smtpClient)
                {
                    _smtpClient = new SmtpClient(EMAIL_SMTP_SERVER);
                    _smtpClient.Port = PORT;
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    _smtpClient.UseDefaultCredentials = false;
                    System.Net.NetworkCredential credentials =
                        new System.Net.NetworkCredential(USERNAME, PASSWORD);
                    _smtpClient.EnableSsl = true;
                    _smtpClient.Credentials = credentials;
                }
                return _smtpClient;
            }
        }


        public void SendMessage(string Destination, string Message, string Subject)
        {
            new Thread(() =>
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(EMAIL_ADDRESS);
                mailMessage.To.Add(Destination);
                mailMessage.Body = Message;
                mailMessage.Subject = Subject;

                Client.Send(mailMessage);
            }).Start();
        }
    }
}
