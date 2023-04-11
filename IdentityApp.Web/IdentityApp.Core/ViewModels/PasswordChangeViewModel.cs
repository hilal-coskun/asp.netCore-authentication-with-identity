using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Core.ViewModels
{
    public class PasswordChangeViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        [Display(Name = "Şifre: ")]
        [MinLength(6, ErrorMessage ="Şifreniz en az 6 karakterli olabilir!")]
        public string PasswordOld { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        [Display(Name = "Yeni Şifre: ")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakterli olabilir!")]
        public string PasswordNew { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(PasswordNew), ErrorMessage = "Şifreler aynı değildir!")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz!")]
        [Display(Name = "Yeni Şifre Tekrar: ")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakterli olabilir!")]
        public string PasswordNewConfirm { get; set; }
    }
}
