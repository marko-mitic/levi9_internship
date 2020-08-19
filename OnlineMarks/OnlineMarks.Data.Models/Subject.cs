using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Professor Professor { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
    }
}
