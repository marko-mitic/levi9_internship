using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class StudentSubject
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
