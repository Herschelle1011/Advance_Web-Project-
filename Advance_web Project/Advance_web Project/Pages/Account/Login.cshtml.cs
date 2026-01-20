using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;

namespace Advance_web_Project.Pages.Login
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential credential { get; set; }

        public void OnGet()
        {
            credential = new Credential();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return Page();

            if (credential.Username == "admin" && credential.Password == "admin123")
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, credential.Username)
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return LocalRedirect(returnUrl);
                else
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
