using GetMailWithAttachment.Models;
using GetMailWithAttachment.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GetMailWithAttachment.Controllers
{
    public class HomeController : Controller
    {
        private readonly Services _Services;

        public HomeController(Services Services)
        {
            _Services = Services;
        }

        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isSent = await _Services.SendMailWithAttachment(model);

                if (isSent)
                {
                    TempData["SuccessMessage"] = "Email sent successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "There was an error sending the email. Please try again.";
                }

                return RedirectToAction("SendEmail"); 
            }

            return View(model); 
        }
    }
}
