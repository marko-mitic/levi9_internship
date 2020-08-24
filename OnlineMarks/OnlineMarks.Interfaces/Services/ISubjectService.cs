using OnlineMarks.Data.Models;
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
        Subject Add(string subjectName, string professorName);
        SubjectView GetByName(string name);
        StudentSubject AddStudent(string subjectName, string studentName);
    }
}
