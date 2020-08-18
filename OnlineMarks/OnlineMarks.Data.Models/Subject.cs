using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProfessorId { get; set; }
    }
}
