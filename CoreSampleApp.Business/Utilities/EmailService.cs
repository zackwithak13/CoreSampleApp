using CoreSampleApp.Utilities.SimpleInjector;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CoreSampleApp.Business.Utilities
{
    public static class EmailHelper
    {
        private static readonly IConfiguration _configuration;
        static EmailHelper()
        {
            _configuration = SimpleInjectorAccessor.Container.GetInstance<IConfiguration>();
        }

        public static void SendEmail(string emailTo, string subject, string message, string emailCC = null, string emailBCC = null)
        {
            using (var client = new SmtpClient())
            {
                client.Host = _configuration.GetValue<string>("Email:Host");
                client.Port = _configuration.GetValue<int>("Email:Port");
                client.EnableSsl = _configuration.GetValue<bool>("Email:EnableSsl");

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(emailTo);
                    if(!String.IsNullOrEmpty(emailCC)) emailMessage.CC.Add(emailCC);
                    if(!String.IsNullOrEmpty(emailBCC)) emailMessage.Bcc.Add(emailBCC);
                    emailMessage.From = new MailAddress(_configuration.GetValue<string>("Email:From"));
                    emailMessage.Subject = subject;
                    emailMessage.Body = message;
                    client.Send(emailMessage);
                }
            }
        }
    }
}
