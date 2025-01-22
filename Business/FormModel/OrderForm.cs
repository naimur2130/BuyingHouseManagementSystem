using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.FormModel
{
    public class OrderForm
    {
        [Required]
        public int OrderAmount { get; set; }
        [Required]
        public int SizeId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string ProductId { get; set; }
    }
}
