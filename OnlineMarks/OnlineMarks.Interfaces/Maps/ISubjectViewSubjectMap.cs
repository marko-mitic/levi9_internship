using OnlineMarks.Data.Models;
using OnlineMarks.Data.ViewModels.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Maps
{
    public interface ISubjectViewSubjectMap
    {
        SubjectView Translate(Subject subject);
        IEnumerable<SubjectView> Translate(IEnumerable<Subject> subject);
    }
}
