﻿using AprioriSite.Core.Constants;
using AprioriSite.Infrasructure.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AprioriSite.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserService service;

        public UserController(RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager, IUserService _service)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
