using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class Subject
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Professor Professor { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
        public Subject()
        {
            StudentSubjects = new List<StudentSubject>();
        }
    }
}
