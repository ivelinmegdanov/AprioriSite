using AprioriSite.Core.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AprioriSite.Areas.Admin.Controllers
{
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

        public async Task<IActionResult> ManageUsers()
        {
            var users = await userService.GetUsers();

            return View(users);
        }

        public async Task<IActionResult> Roles(string id) 
        {
            return Ok(id);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = userService.GetUserForEdit(id);

            return View(model);
        }


        public async Task<IActionResult> CreateRole()
        {
            //await roleManager.CreateAsync(new IdentityRole()
            //{
            //    Name = "Administrator"
            //});

            return Ok();
        }
    }
}
