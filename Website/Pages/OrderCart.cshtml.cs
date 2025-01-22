using Business;
using Business.Services;
using Database.DatabaseConnection;
using Database.TableModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class OrderCartModel : PageModel
    {
        public List<OrderCart> OrderCarts { get; set; } = new List<OrderCart>();


        private readonly OrderService _orderService;
        public OrderCartModel(OrderService orderService)
        {
            _orderService = orderService;
        }
        public void OnGet()
        {
            var result = new OrderService().OrderList();
            if (result.Success)
            {
                OrderCarts = (List<OrderCart>)result.Data;
            }
        }

        public IActionResult OnPost(string id)
        {
            if(id==null)
            {
                return Page();
            }
            Result result = _orderService.DeleteOrder(id);
            if (result.Success)
            {
                return Page();
            }
            else
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return Page();
            }
        }
    }
}
