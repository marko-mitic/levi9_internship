using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class SubjectGrade
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Student Student { get; set; }
        [Required]
        public Subject Subject { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
