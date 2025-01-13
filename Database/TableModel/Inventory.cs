using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.TableModel
{
    public class Inventory : TimeAndDate
    {
        [Key]
        public int InventoryId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
    }
}
