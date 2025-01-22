using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.TableModel
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; } = Guid.NewGuid().ToString();
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
        [Required]
        public string? ImageUrl { get; set; }
        public bool IsAvailable { get; set; }

    }
}
