using Microsoft.AspNetCore.Identity;
using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class User : IdentityUser<Guid>
    {   
        public string Name { get; set; } // IdentityUser
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
