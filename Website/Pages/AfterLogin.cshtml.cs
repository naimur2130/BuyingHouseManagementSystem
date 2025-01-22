using Business;
using Business.FormModel;
using Business.Services;
using Database.TableModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Website.Pages
{
    public class AfterLoginModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly OrderService _orderService;

        public AfterLoginModel(ProductService productService, OrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        [BindProperty]
        public OrderForm OrderForm { get; set; }

        public List<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetProductsAsync();
        }

        public IActionResult OnPostAddToCartAsync(string productId, int categoryId, int sizeId, int brandId, int orderAmount)
        {
            if (string.IsNullOrEmpty(productId) || orderAmount <= 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid product or quantity.");
                return Page();
            }

            OrderForm = new OrderForm
            {
                ProductId = productId,
                CategoryId = categoryId,
                SizeId = sizeId,
                BrandId = brandId,
                OrderAmount = orderAmount,

            };

            Result result = _orderService.AddOrder(OrderForm);

            if(result.Success)
            {
                return RedirectToPage("/AfterLogin");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid input!");
                return Page();
            }
        }

    }

}
