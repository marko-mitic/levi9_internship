using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Professor : User
    {
        public List<Subject> Subjects { get; set; }
        public Professor()
        {
            Role = UserRole.Professor;
        }
    }
}
