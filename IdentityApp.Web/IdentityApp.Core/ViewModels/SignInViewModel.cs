﻿using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Core.ViewModels
{
    public class SignInViewModel
    {
        [EmailAddress(ErrorMessage = "Email formatı yanlıştır!")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz!")]
        [Display(Name = "Email: ")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        [Display(Name = "Şifre: ")]
        public string? Password { get; set; }

        [Display(Name = "Beni Hatırla ")]
        public bool RememberMe { get; set; }
    }
}
