using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FormModel
{
    public class ProductForm
    {
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int SizeId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        public double LatestPrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
