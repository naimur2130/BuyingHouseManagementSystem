using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.TableModel
{
    public class UserInfo : TimeAndDate 
    {
        [Key]
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? UserPasswordHash { get; set; }
        public bool IsActive { get; set; }
    }
}
