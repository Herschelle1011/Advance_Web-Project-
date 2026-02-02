using Microsoft.AspNetCore.Identity;
namespace Advance_web_Project.Models
    
{
    public class Users : IdentityUser
    {
        public string Fullname { get; set; }
    }
}
