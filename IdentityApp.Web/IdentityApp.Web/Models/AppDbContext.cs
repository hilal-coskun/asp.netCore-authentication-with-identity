using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityApp.Web.Models
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>
    {

    }
}
