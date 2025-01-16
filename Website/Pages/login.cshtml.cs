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
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Result result = new UserService().Login(loginForm);
            if (result.Success)
                return RedirectToPage("/Index");
            else return Page();
        }
    }
}
