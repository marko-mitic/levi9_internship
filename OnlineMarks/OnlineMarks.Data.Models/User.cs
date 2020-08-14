using Microsoft.AspNetCore.Identity;
using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class User
    {   
        public Guid Id { get; set; }
        public string Name { get; set; } // IdentityUser
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
