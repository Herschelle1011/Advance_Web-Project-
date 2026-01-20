using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Advance_web_Project.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential credential { get; set; }

        public void OnGet()
        {
            credential = new Credential();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (credential.Username == "admin" && credential.Password == "admin123")
            {
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return Page();
        }

        public class Credential
        {
            [Required(ErrorMessage = "Username is Required")]
            public string Username { get; set; } = string.Empty;

            [Required(ErrorMessage = "Password is Required")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
        }
    }
}
