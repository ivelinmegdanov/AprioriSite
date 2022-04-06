using AprioriSite.Core.Constants;
using AprioriSite.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AprioriSite.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<IdentityUser> userManager;

        private readonly IUserService userService;

        public UserController(RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager, IUserService _userService)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MyProfile()
        {
            var users = await userService.GetUsers();

            return View(users);
        }

        public async Task<IActionResult> EditProfile(string id)
        {
            var model = await userService.GetUserForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await userService.UpdateUser(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Успешен запис!";
                return Redirect("/user/myprofile");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }
            return Ok();
        }
    }
}
