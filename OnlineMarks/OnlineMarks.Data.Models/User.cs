using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; } // IdentityUser
    }

    public class UserRole : IdentityRole<Guid>
    {

    }
}
