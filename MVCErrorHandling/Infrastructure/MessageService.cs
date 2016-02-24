using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web;

namespace MVCErrorHandling.Infrastructure
{
    public class MessageService : IMessageProvider
    {
    
        public void SendEmail(EmailDetails details)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(details.From);
            email.To.Add(details.ToAddresses);
            email.Subject = Assembly.GetCallingAssembly().GetName().Name + "has error occured!";
            email.Body = details.Body;
            email.IsBodyHtml = true;
            
            NetworkCredential credentials = new NetworkCredential(details.From, "824673915q");
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = credentials;
            client.Send(email);

        }
    }
}