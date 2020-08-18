using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Professor : User
    {
        public Subject Subject { get; set; }
        public new const string Role = UserRole.Professor;
    }
}
