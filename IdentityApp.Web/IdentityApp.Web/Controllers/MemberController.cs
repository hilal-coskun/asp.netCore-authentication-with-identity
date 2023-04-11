using IdentityApp.Web.Extensions;
using IdentityApp.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;
using IdentityApp.Core.Models;
using IdentityApp.Repository.Models;
using IdentityApp.Service.Services;

namespace IdentityApp.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;
        private readonly IMemberService _memberService;

        private string userName => User.Identity!.Name!;

        public MemberController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IFileProvider fileProvider, IMemberService memberService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _fileProvider = fileProvider;
            _memberService = memberService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _memberService.GetUserViewModelByUserNameAsync(userName));
        }

        public async Task LogOut()
        {
            await _memberService.LogoutAsync();
            
        }

        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            if (!await _memberService.CheckPasswordAsync(userName, request.PasswordOld))
            {
                ModelState.AddModelError(string.Empty, "Eski şifreniz yanlış!");
                return View();
            }

            var (isSuccess, errors) = await _memberService.ChangePasswordAsync(userName, request.PasswordOld, request.PasswordNew);

            if (!isSuccess)
            {
                ModelState.AddModelErrorList(errors!.Select(x => x.Description).ToList());
                return View();
            }

            TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirilmiştir!";

            return View();
        }

        public async Task<IActionResult> UserEdit()
        {
            ViewBag.genderList = _memberService.GetGenderSelectList();

            var result = await _memberService.GetUserEditViewModelAsync(userName);
             
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var (isSuccess, errors) = await _memberService.EditUserAsync(request, userName);


            if (!isSuccess)
            {
                ModelState.AddModelErrorList(errors!.Select(x => x.Description).ToList());
                return View();
            }

            TempData["SuccessMessage"] = "Kullanıcı  bilgileri başarıyla değiştirilmiştir!";

            var result = await _memberService.GetUserEditViewModelAsync(userName);

            return View(result);
        }

        [HttpGet]
        public IActionResult Claims()
        {
            var result = _memberService.GetClaims(User);

            return View(result);
        }

        [Authorize(Policy = "IstanbulPolicy")]
        [HttpGet]
        public IActionResult IstanbulPage()
        {
            return View();
        }


        [Authorize(Policy = "ExchangePolicy")]
        [HttpGet]
        public IActionResult ExchangePage()
        {
            return View();
        }


        [Authorize(Policy = "ViolencePolicy")]
        [HttpGet]
        public IActionResult ViolencePage()
        {
            return View();
        }


        public IActionResult AccessDenied(string returnUrl)
        {
            string message = string.Empty;
            message = "Bu sayfayı görüntülemeye yetkiniz yoktur. Yetki almak için yöneticiniz ile görüşebilirsiniz";
            ViewBag.message = message;

            return View();
        }
    }
}
