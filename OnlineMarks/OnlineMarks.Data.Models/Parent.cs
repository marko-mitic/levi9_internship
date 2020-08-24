using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Parent : User
    {
        [Required]
        public List<Student> Children { get; set; }

        public Parent()
        {
            Role = UserRole.Parent;
        }
    }
}
