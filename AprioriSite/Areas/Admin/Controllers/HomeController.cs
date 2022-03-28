using Microsoft.AspNetCore.Mvc;

namespace AprioriSite.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
