using IdentityApp.Web.Models;
using IdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public MemberController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);

            var userViewModel = new UserViewModel
            {
                Email = user.Email == null ? " " : user.Email,
                PhoneNumber = user.PhoneNumber == null ? " " : user.PhoneNumber,
                UserName = user.UserName == null ? " " : user.UserName
            };

            return View(userViewModel);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
            
        }

        public IActionResult PasswordChange()
        {
            return View();
        }
    }
}
