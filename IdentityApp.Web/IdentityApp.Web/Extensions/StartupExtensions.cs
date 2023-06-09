﻿using IdentityApp.Repository.Models;
using IdentityApp.Web.CustomValidations;
using IdentityApp.Web.Localization;
using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void AddIdentityWithExtension(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(2);
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzxwq1234567890_.";

                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;

            }).AddErrorDescriber<LocalizationIdentityErrorDescriber>()
            .AddUserValidator<UserValidator>()
            .AddPasswordValidator<PasswordValidator>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();

        }
    }
}
