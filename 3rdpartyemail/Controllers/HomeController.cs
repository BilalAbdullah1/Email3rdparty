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
        public IActionResult Index(IFormCollection form)
        {

            try
            {


                string name = form["name"];
                string email = form["email"];
                string message = form["message"];

                SmtpClient smtpclient = new SmtpClient("smpt@gmail.com", 587);
                smtpclient.EnableSsl = true;
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new NetworkCredential("bilalabdullah@gmail.com", "AppPAssword");
                MailMessage msg = new MailMessage("bilal@gmail.com", "shadab@gmail.com");
                msg.Subject = name + "'s concern";
                msg.Body = message;
                msg.ReplyTo = new MailAddress(email);
                smtpclient.Send(msg);

                return View();

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}