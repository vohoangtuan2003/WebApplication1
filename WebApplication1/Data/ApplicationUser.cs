using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Data
{
    public partial class ApplicationUser: IdentityUser
    {
        public string? Name { get; set; }

        public string? ProfilePicture { get;set; }


    }
}
