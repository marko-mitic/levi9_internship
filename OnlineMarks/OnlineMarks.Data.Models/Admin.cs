using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Admin : User
    {
        public Admin()
        {
            Role = UserRole.Admin;
        }
    }
}
