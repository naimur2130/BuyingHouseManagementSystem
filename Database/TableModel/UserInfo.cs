﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.TableModel
{
    public class UserInfo
    {
        [Key, MaxLength(128)]
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        [Required, MaxLength(50)]
        public string? UserName { get; set; }
        [Required, MaxLength(40)]
        public string? UserEmail { get; set; }
        [Required, MaxLength(20)]
        public string? UserPasswordHash { get; set; }
        public bool IsActive { get; set; }
    }
}
