using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal_Web_App.Models;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {

            MimeMessage mimeMessage = new();

            MailboxAddress mailboxAddressFrom = new("Admin", "ozgur.gokmen735@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new("Useer", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            BodyBuilder bodyBuilder = new();
            bodyBuilder.TextBody = mailRequest.Body;


            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("ozgur.gokmen735@gmail.com", "jofgnmxizdrczabd");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
