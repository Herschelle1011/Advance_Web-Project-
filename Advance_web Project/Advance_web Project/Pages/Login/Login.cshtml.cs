using Advance_web_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Advance_web_Project.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;
        public LoginModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Credential credential { get; set; }  
        public void OnGet()
        {
            credential = new Credential();
        }

        public async Task <IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.Users
          .FirstOrDefaultAsync(u => u.UserName == credential.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return Page();
            }


            return RedirectToPage("/Index");
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
