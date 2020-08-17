using Microsoft.AspNetCore.Identity;
using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class User
    {   
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; } // IdentityUser
        [Required]
        [StringLength(8,MinimumLength = 4,ErrorMessage ="You must specify password between 4 and 8 characters")]     
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
