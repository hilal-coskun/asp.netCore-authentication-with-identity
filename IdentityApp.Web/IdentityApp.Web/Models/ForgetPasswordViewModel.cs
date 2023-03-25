﻿using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Web.Models
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Email formatı yanlıştır!")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz!")]
        [Display(Name = "Email: ")]
        public string? Email { get; set; }
    }
}
