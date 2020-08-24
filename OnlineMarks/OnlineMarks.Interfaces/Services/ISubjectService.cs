using OnlineMarks.Data.ViewModels.Subjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Services
{
    public interface ISubjectService
    {
        IEnumerable<SubjectView> GetAll();
        SubjectView GetById(Guid id);
        void Add(string subjectName, string professorName);
        SubjectView GetByName(string name);
        void AddStudent(string subjectName, string studentName);
    }
}
