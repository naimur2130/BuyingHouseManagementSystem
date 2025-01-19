using Microsoft.AspNetCore.Mvc;
using Business;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Business.FormModel;
using Business.Services;


namespace Website.Pages
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public UserLogin loginForm { get; set; }

        private readonly UserService _userService;

        // Constructor with Dependency Injection
        public loginModel(UserService userService)
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
            if (loginForm == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // Attempt login
            Result result = _userService.Login(loginForm);

            if (result.Success)
            {
                // Redirect to the home page if successful
                return RedirectToPage("/Index");
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
