using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Web.Localization
{
    public class LocalizationIdentityErrorDescriber:IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new() { Code = "DuplicateUserName", Description = $"Bu {userName} daha önce başkası tarafından alınmıştır!" };
            //return base.DuplicateUserName(userName);
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = "DuplicateEmail", Description = $"Bu {email} daha önce başkası tarafından alınmıştır!" };
            //return base.DuplicateEmail(email);
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = "PasswordToShort", Description = $"Şifre en az 6 karakterli olmalıdır!" };
            //return base.PasswordTooShort(length);
        }
    }
}
