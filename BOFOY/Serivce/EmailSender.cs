using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOFOY.Serivce
{
    public class EmailSender
    {       

        public void Send(String email, String subject, string contents)
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@localhost.com", "Example User");
            var to = new EmailAddress(email, "Example User");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            
        }
    }
}
