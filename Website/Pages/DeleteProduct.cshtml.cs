using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Business.FormModel;
using Business.Services;
using Business;

namespace Website.Pages
{
    public class DeleteProductModel : PageModel
    {
        private readonly ProductService _productService;

        [BindProperty]
        public ProductForm Delete { get; set; }
        public string Message { get; set; } // To display success/error messages
        public bool IsSuccess { get; set; }

        public DeleteProductModel(ProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            // Handle GET requests if necessary
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Message = "Please fill out all required fields.";
                IsSuccess = false; Message = "Please fill out all required fields.";
                return Page();
            }

            // Add product using the service
            Result result = _productService.DeleteProduct(Delete);

            if (result.Success)
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