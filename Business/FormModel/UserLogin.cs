using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FormModel
{
    public class UserLogin
    {
        [Required]
        public string? UserEmail { get; set; }
        [Required,MinLength(8)]
        public string? Password { get; set; }
    }
}
