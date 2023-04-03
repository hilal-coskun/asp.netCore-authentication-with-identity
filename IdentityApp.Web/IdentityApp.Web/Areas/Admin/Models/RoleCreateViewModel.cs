using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Web.Areas.Admin.Models
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Rol isim alanı boş bırakılamaz!")]
        [Display(Name = "Rol isim alanı: ")]
        public string Name { get; set; }
    }
}
