using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Grade
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int Value { get; set; }
        public SubjectGrade SubjectGrade { get; set; }
    }
}
