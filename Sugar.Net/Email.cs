using System.Collections;
using System.Net.Mail;

namespace Sugar.Net
{
    internal class Email
    {
        public void Send(string host, MailMessage mailMessage)
        {
            var smtpClient = new SmtpClient(host);
            Send(smtpClient, mailMessage);
        }
        
        public void Send(SmtpClient smtpClient, MailMessage mailMessage)
        {
            smtpClient.Send(mailMessage);
        }

        public static void Send(string host, MailAddress from,
            string subject, string body, params MailAddress[] recipients)
        {
            var smtpClient = new SmtpClient(host);
            Send(smtpClient, from, subject, body, recipients);
        }

        public static void Send(SmtpClient smtpClient, MailAddress from, 
            string subject, string body, params MailAddress[] recipients)
        {
            var message = new MailMessage
            {
                From = @from,
                Subject = subject,
                Body = body
            };
            recipients.EachOf<MailAddress>(x => message.To.Add(x));
            smtpClient.Send(message);
        }
    }
}