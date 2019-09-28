using BOFOY.Models;
using BOFOY.Serivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOFOY.Controllers
{
    public class EmailController : Controller
    {
        
        public ActionResult SendEmail()
        {
            return View(new SendEmailViewModel());
        }

        
        [HttpPost]
        public ActionResult SendEmail(SendEmailViewModel se)
        {
            try
            {
                string email = se.Email;
                string subject = se.Subject;
                string content = se.Content;

                EmailSender es = new EmailSender();
                es.Send(email, subject, content);

                ViewBag.Result = "Email has been send.";
                return View(new SendEmailViewModel());
            }
            catch
            {
                return View();
            }
        }

    }  
}
