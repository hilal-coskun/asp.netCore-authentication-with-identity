using IdentityApp.Web.Areas.Admin.Models;
using IdentityApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users
                .ToListAsync();

            var userViewList = users
                .Select(x => new UserViewModel()
                {
                    Name = x.UserName,
                    Id = x.Id,
                    Email = x.Email
                }).ToList();

            return View(userViewList);
        }
    }
}
