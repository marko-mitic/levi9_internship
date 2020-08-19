﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Data.Models
{
    public class SubjectGrade
    {
        public Guid Id { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
