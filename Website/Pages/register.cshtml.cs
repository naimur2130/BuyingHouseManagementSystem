using Microsoft.AspNetCore.Mvc;
using Business;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Business.FormModel;
using Business.Services;


namespace Website.Pages
{
    public class registerModel : PageModel
    {

        [BindProperty]
        public UserRegister RegisterForm { get; set; }
        private readonly UserService _userService;

        public registerModel(UserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(RegisterForm==null)
            {
                ModelState.AddModelError(string.Empty, "Invalid registration attempt");
                return Page();
            }

            Result result = _userService.Registration(RegisterForm);
            if(result.Success)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid input!");
                return Page();
            }
        }
    }
}
