using Microsoft.AspNetCore.Identity;

namespace Hospital2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
