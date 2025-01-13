using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.TableModel
{
    public class Price
    {
        [Key]
        public string? ProductId { get; set; }
        [Required]
        public double PriceAmount { get; set; }
        [Required]
        public double DiscountPrice { get; set; }
    }
}
