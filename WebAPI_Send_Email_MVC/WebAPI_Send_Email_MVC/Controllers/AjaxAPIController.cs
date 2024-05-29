using WebAPI_Send_Email_MVC.Models;
using System;
using System.Web.Http;


using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;

namespace WebAPI_Send_Email_MVC.Controllers
{
    public class AjaxAPIController : ApiController
    {
        [Route("api/AjaxAPI/SendEmail")]
        [HttpPost]
        public string SendEmail(EmailModel email)
        {
            //Read SMTP section from Web.Config.
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

            using (MailMessage mm = new MailMessage(smtpSection.From, email.Email))
            {
                mm.Subject = email.Subject;
                mm.Body = email.Body;
              
                mm.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = smtpSection.Network.Host;
                    smtp.EnableSsl = smtpSection.Network.EnableSsl;
                    NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCred;
                    smtp.Port = smtpSection.Network.Port;
                    smtp.Send(mm);
                }
            }

            return "Email sent sucessfully.";
        }
    }
}
