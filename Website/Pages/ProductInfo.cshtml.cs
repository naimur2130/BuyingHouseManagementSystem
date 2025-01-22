using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Business.Services;
using System.Collections.Generic;
using Database.TableModel;
using Business.FormModel;

namespace Website.Pages
{
    public class ProductInfoModel : PageModel
    {
        
        public List<Product> products {  get; set; }= new List<Product>();

        public void OnGet()
        {
            var result = new ProductService().List();
            if(result.Success)
            {
                products = (List<Product>)result.Data;
            }
        }
    }
}

