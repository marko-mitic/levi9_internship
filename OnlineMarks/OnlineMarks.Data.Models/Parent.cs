using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Parent : User
    {
        public List<Student> Children { get; set; }

        public Parent()
        {
            Role = UserRole.Parent;
        }
    }
}
