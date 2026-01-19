using Microsoft.AspNetCore.Mvc;

namespace Advance_web_Project.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Post()
        {
            if(!ModelState.IsValid)
            {
                return View("Login");
            }

            return RedirectToPage("/Index");
        }

    }
}
