using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Business.Services;
using System.Collections.Generic;

namespace Website.Pages
{
    public class ProductInfoModel : PageModel
    {
        private readonly ProductService _productService;

        public ProductInfoModel(ProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public string FilterType { get; set; }

        [BindProperty]
        public string FilterValue { get; set; }

        public JsonResult OnPostFilterProducts()
        {
            try
            {
                var products = _productService.ReadProduct(FilterType, FilterValue);
                return new JsonResult(new { success = true, data = products });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }
    }
}

