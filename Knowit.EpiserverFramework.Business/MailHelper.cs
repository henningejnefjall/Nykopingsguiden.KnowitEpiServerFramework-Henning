using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Knowit.EpiserverFramework.Business
{
    public class MailHelper
    {
        public static void Send(string To, string From, string Subject, string Body)
        {
            var host = ConfigurationManager.AppSettings["SmtpServer"];

            // Do not send email if SmtpServer is unset in config
            
            if (!String.IsNullOrEmpty(host))
            {
                var encoding = System.Text.Encoding.UTF8;

                SmtpClient client = new SmtpClient(host);

                MailAddress from = new MailAddress(From);
                MailAddress to = new MailAddress(To);

                MailMessage message = new MailMessage(from, to);
                message.Body = Body;
                message.IsBodyHtml = true;
                message.BodyEncoding = encoding;

                message.Subject = Subject;
                message.SubjectEncoding = encoding;
                try
                {
                    client.Send(message);
                }
                catch(Exception ex)
                {
                    
                }
            }
        }
        
    }
}