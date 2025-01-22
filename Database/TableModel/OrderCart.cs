using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.TableModel
{
    public class OrderCart
    {
        [Key]
        public string? TempOrderID { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public int OrderAmount { get; set; }
        [Required]
        public int SizeId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string? ProductId { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public bool IsProcessed { get; set; }
    }
}
