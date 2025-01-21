using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Business.FormModel;
using Business.Services;
using Business;

namespace Website.Pages
{
    public class ProductManagementModel : PageModel
    {
        private readonly ProductService _productService; // Inject the product service

        [BindProperty]
        public ProductForm Product { get; set; } // To bind form inputs to this property

        public string Message { get; set; } // To display success/error messages
        public bool IsSuccess { get; set; }

        public ProductManagementModel(ProductService productService)
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
                IsSuccess = false;
                return Page();
            }

            // Add product using the service
            Result result = _productService.AddProduct(Product, "admin@gmail.com");

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
