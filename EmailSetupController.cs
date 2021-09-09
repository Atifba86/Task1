using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gmail.Models;
using System.Net;
using System.Net.Mail;


namespace gmail.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(gmail.Models.gmail model)
        {
            MailMessage mm = new MailMessage(model.From, model.To);
            mm.Subject=model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;


            NetworkCredential nc = new NetworkCredential("rme86621@gmail.com", "meme86621@t!F");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            //if the mail have been sended then show....

            ViewBag.Message = "Mail Sended Sucessfully";
            return View();
        }

    }
}