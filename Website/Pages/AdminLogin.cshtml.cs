using Business.FormModel;
using Business.Services;
using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class AdminLoginModel : PageModel
    {

        [BindProperty]
        public UserLogin AdminForm { get; set; }

        private readonly UserService _userService;

        // Constructor with Dependency Injection
        public AdminLoginModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check if loginForm is null
            if (AdminForm == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // Attempt login
            Result result = _userService.Login(AdminForm);

            if (result.Success)
            {
                // Redirect to the home page if successful
                return RedirectToPage("/Error");
            }
            else
            {
                // Add error message and reload the page
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }
        }
    }
}
