using OnlineMarks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.ViewModels.Subjects
{
    public class SubjectView
    {
        public string Name { get; set; }
        public Professor Professor { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
    }
}
