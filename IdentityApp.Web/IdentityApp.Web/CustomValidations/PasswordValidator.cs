using IdentityApp.Repository.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Web.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var errors = new List<IdentityError>();

            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new() { Code = "PasswordNotContainUserName", Description = "Şifre alanı kullanıcı adı içeremez" });
            }

            if (password!.ToLower().StartsWith("1234"))
            {
                errors.Add(new() { Code = "PasswordNotContain1234", Description = "Şifre alanı ardışık sayı içeremez" });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
