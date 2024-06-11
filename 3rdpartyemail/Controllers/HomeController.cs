using _3rdpartyemail.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace _3rdpartyemail.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Index(IFormCollection form)
        {
            try
            {
                string name = form["nm"];
                string email = form["em"];
                string message = form["msg"];

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("bilalabdullah5393@gmail.com", "bqyawuynnpdkhxrl");

                MailMessage msg = new MailMessage("bilalabdullah5393@gmail.com", "bilalabdullah5393@gmail.com");
                msg.Subject = name + "'s Concern";
                msg.Body = message;
                msg.ReplyTo = new MailAddress(email);
                client.Send(msg);

                ViewBag.Message = "Mail sent successfully";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();

        }

    }
}