using AprioriSite.Core.Constants;
using AprioriSite.Core.Models;
using AprioriSite.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AprioriSite.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<IdentityUser> userManager;

        private readonly IUserService userService;

        private readonly ApplicationDbContext context;

        public UserController(RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager, IUserService _userService, ApplicationDbContext _context)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            userService = _userService;
            context = _context;
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

        public async Task<IActionResult> MyOrders(string id)
        {
            var order = await userService.GetUserOrders(id);

            return View(order);
        }

        public async Task<IActionResult> EditProfile(string id)
        {
            if (id != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                ViewData[MessageConstant.SuccessMessage] = "You can only edit your things!";
                return Redirect("/user/myprofile");
            }

            var model = await userService.GetUserForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserEditViewModel model)
        {
            if (model.Id != User.FindFirstValue(ClaimTypes.NameIdentifier)) 
            {
                ViewData[MessageConstant.SuccessMessage] = "You can only edit your things!";
                return Redirect("/user/myprofile");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await userService.UpdateUser(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Successful!";
                return Redirect("/user/myprofile");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Error!";
            }
            return Ok();
        }
    }
}
