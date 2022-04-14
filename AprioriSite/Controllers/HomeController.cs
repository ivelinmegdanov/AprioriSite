using AprioriSite.Core.Constants;
using AprioriSite.Core.Contracts;
using AprioriSite.Core.Models;
using AprioriSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AprioriSite.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService _emailService)
        {
            _logger = logger;
            emailService = _emailService;
        }

        public IActionResult Howitworks()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(EmailViewModel model)
        {
            emailService.AddEmail(model);

            return Redirect("/home/contactus");
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}