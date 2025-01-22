using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Business.FormModel;
using Business.Services;
using Business;

namespace Website.Pages
{
    public class UpdateProductModel : PageModel
    {
        private readonly ProductService _productService;

        [BindProperty]
        public ProductForm Update { get; set; }
        

        public UpdateProductModel(ProductService productService)
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
                return Page();
            }

            // Add product using the service
            Result result = _productService.UpdateProduct(Update);

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
