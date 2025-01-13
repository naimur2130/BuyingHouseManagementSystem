using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.TableModel
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string? BrandName { get; set; }
    }
}
