using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.TableModel
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }
        [Required]
        public string? SizeType { get; set; }
    }
}
