using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AprioriSite.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
