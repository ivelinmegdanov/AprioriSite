using AprioriSite.Core.Constants;
using AprioriSite.Core.Contracts;
using AprioriSite.Core.Models;
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

        public async Task<IActionResult> AdminPanel()
        {
            return View();
        }

        public async Task<IActionResult> AddItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(AddItemViewModel model)
        {
            userService.AddItem(model);

            return Redirect("/admin/user/adminpanel");
        }

        public async Task<IActionResult> Roles(string id) 
        {
            return Ok(id);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await userService.GetUserForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await userService.UpdateUser(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Успешен запис!";
                return Redirect("/admin/user/adminpanel");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }
            return Ok();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var model = await userService.GetUserForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserEditViewModel model)
        {
            if (await userService.DeleteUser(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Success!";
                return Redirect("/admin/user/manageusers");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Error!";
            }
            return Ok();
        }

        public async Task<IActionResult> CreateRole()
        {
            //await roleManager.CreateAsync(new IdentityRole()
            //{
            //    Name = "Administrator"
            //});

            return Ok();
        }

        public async Task<IActionResult> ManageUserOrders()
        {
            var userOrders = await userService.GetAllUserOrders();

            return View(userOrders);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserOrders(UserOrdersViewModel model)
        {
            var successfull = await userService.ConfirmOrder(model);

            if (successfull)
            {
                ViewData[MessageConstant.SuccessMessage] = "Success!";
            }
            else 
            {
                ViewData[MessageConstant.ErrorMessage] = "Error!";
            }

            return Redirect("/admin/user/manageuserorders");
        }

        public async Task<IActionResult> Emails()
        {
            var userEmails = await userService.GetAllEmails();

            return View(userEmails);
        }

        [HttpPost]
        public async Task<IActionResult> Emails(EmailViewModel model)
        {
            if (await userService.DeleteEmail(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Success!";
                return Redirect("/admin/user/emails");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Error!";
            }
            return Ok();
        }
    }
}
