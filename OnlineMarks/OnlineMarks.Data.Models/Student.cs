using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Student : User
    {
        public List<StudentSubject> StudentSubjects { get; set; }
        [Required]
        public Parent Parent { get; set; }
        public Student()
        {
            Role = UserRole.Student;
        }
    }
}
