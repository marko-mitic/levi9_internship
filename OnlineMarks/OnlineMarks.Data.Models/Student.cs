using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Student : User
    {
        public List<Subject> Subjects { get; set; }
        public Student()
        {
            Role = UserRole.Student;
        }
    }
}
