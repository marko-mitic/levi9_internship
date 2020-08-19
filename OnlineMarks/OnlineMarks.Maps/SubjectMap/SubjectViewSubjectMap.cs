﻿using OnlineMarks.Data.Models;
using OnlineMarks.Data.ViewModels.Subjects;
using OnlineMarks.Interfaces.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMarks.Maps.SubjectMap
{
    public class SubjectViewSubjectMap : ISubjectViewSubjectMap
    {
        public SubjectView Translate(Subject subject)
        {
            if (subject == null)
                return null;

            var temp = new SubjectView() { Name = subject.Name, Professor = subject.Professor, StudentSubjects = subject.StudentSubjects };
            return temp;
        }

        public IEnumerable<SubjectView> Translate(IEnumerable<Subject> subjects)
        {
            if (subjects == null)
                return null;

            return subjects.Select(x => Translate(x));
        }
    }
}