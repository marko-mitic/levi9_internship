using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
