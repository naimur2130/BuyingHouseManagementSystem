using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FormModel
{
    public class UserForm
    {
        [Required, MaxLength(50)]
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required, MinLength(8)]
        public string? UserPassword { get; set; }
        public bool IsActive { get; set; }
    }
}
