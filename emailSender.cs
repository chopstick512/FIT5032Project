using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Cafe.Serivces
{
    public class EmailSender
    {
        private const String apiKey = "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";
        public void Send(String email, String subject, String contents)
        {

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@localhost.com", "Example User");
            var to = new EmailAddress(email, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);       
            var response = client.SendEmailAsync(msg);
        }
        public void NewSend(String email, String subject, String contents, string path, string fileName)
        {

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@localhost.com", "Example User");
            var to = new EmailAddress(email, "");
            var plainTextContent = contents;
            var htmlContent = "<p> Dear customer </p>" + contents + "<p>Thank you </p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
             // attachment feature
            var bytes = File.ReadAllBytes(path);
            msg.AddAttachment(fileName, Convert.ToBase64String(bytes));

            var response = client.SendEmailAsync(msg);

        }
    }
}
