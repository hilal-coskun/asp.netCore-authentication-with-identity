using IdentityApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Web.Controllers
{
    public class MemberController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;

        public MemberController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
            
        }
    }
}
