using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AirlinedatabaseSystem.Pages.Admin
{
    public class AdminLoginModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public AdminLoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            // Check if username and password match admin credentials
            string adminUsername = _configuration["AdminCredentials:Username"];
            string adminPassword = _configuration["AdminCredentials:Password"];

            if (Username == adminUsername && Password == adminPassword)
            {
                // Admin login successful, redirect to admin dashboard or protected page
                return RedirectToPage("/Admin/Dashboard");
            }
            else
            {
                // Admin login failed, display error message
                TempData["ErrorMessage"] = "Invalid username or password.";
                return Page();
            }
        }
    }
}
