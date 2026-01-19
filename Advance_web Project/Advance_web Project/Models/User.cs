using Microsoft.AspNetCore.Identity;


namespace Advance_web_Project.Models
{
    public class User : IdentityUser
    {
        public string fullName { get; set; } = string.Empty;
    }
}
