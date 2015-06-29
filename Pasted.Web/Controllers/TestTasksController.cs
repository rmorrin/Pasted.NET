using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hangfire;
using System.Net.Mail;
using Pasted.Tasks;

namespace Pasted.Web.Controllers
{
    public class TestTasksController : Controller
    {
        // GET: TestTasks
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendSingleEmail()
        {

            MailAddress mailTo = new MailAddress("test_recipient@blabla.com", "You and Me");

            SendEmails sendEmail = new SendEmails();

            //sendEmail.SendSingle(mailTo);

            BackgroundJob.Enqueue(() => sendEmail.SendSingle());

            ViewBag.LastExecution = "Send Single email - HangFire";

            return View("Index");
        }

        public ActionResult SendMultipleEmail()
        {
            return View();
        }

        public ActionResult PutMessage()
        {
            MessageQueue mq = new MessageQueue();
            BackgroundJob.Enqueue(() => mq.Put("Hola from Asp.Net"));

            ViewBag.LastExecution = "Put Message in queue.. see the MQ console";

            return View("Index");
        }

    }
}
