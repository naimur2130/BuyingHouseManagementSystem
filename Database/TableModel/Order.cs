using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.TableModel
{
    public class Order 
    {
        [Key]
        public string OrderId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string? UserId { get; set; }
        [Required]
        public int OrderAmount { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
