﻿namespace IdentityApp.Web.Services
{
    public interface IEmailService
    {
        Task SendResetPasswordEmail(string resetEmailLink, string ToEmail);
    }
}
