using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace AirNiceWebMVC.Helper
{
    public interface IEmailSender
    {
      Task  SendEmailAsync(string email, string subject, string htmlMessage);
        void MailSender(string email, string subject, string messageBody);
    }
    public class EmailSender : IEmailSender
    {
        // Our private configuration variables
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;

        // Get our parameterized configuration
        public EmailSender(string host, int port, bool enableSSL, string userName, string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
        }

        // Use our configuration to send the email by using SmtpClient
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {


            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, htmlMessage) { IsBodyHtml = true }
            );

        }


        public  void MailSender(string email, string subject, string messageBody)
        {
            MailMessage msg = new MailMessage
            {
                From = new MailAddress(userName),
            };
            msg.To.Add(email);

            msg.Subject = subject;
            msg.Body = messageBody;


            SmtpClient client = new SmtpClient
            {
                Host = host
            };
            NetworkCredential credential = new NetworkCredential
            {  // Server Email credential
                UserName = userName,
                Password = password
            };
            client.Credentials = credential;
            client.EnableSsl = enableSSL;
            client.Port = port;
            try
            {
                client.Send(msg);
            }


            catch
            {
                throw new Exception("Unabel to send Message to your email at this time!");
            }
        }


    }
}
