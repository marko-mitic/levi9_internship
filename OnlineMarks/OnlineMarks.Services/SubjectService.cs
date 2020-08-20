using OnlineMarks.Data.Models;
using OnlineMarks.Data.ViewModels.Subjects;
using OnlineMarks.Interfaces.Maps;
using OnlineMarks.Interfaces.Repository;
using OnlineMarks.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISubjectViewSubjectMap _subjectViewUserMap;
        private readonly IProfessorRepository _professorRepository;
        private readonly IStudentRepository _studentRepository;

        public SubjectService(ISubjectRepository subjectRepository, ISubjectViewSubjectMap subjectViewUserMap,
            IProfessorRepository professorRepository, IStudentRepository studentRepository)
        {
            _subjectRepository = subjectRepository;
            _subjectViewUserMap = subjectViewUserMap;
            _professorRepository = professorRepository;
            _studentRepository = studentRepository;
        }
        public void Add(string subjectName, string professorName)
        {
            var professor = _professorRepository.GetByName(professorName);

            var subject = new Subject() { Name = subjectName, Id = Guid.NewGuid(), Professor = professor };
            _subjectRepository.Add(subject);
        }

        public void AddStudent(string subjectName, string studentName)
        {
            var subject = _subjectRepository.GetByName(subjectName);
            var student = _studentRepository.GetByName(studentName);

            var studentSubject = new StudentSubject() { Student = student, StudentId = student.Id, Subject = subject, SubjectId = subject.Id };

            subject.StudentSubjects.Add(studentSubject);
            student.StudentSubjects.Add(studentSubject);

            _subjectRepository.SaveChanges();
        }

        public IEnumerable<SubjectView> GetAll()
        {
            var subjectList = _subjectRepository.GetAll();
            return _subjectViewUserMap.Translate(subjectList);
        }

        public SubjectView GetById(Guid id)
        {
            var subject = _subjectRepository.Get(id);
            return _subjectViewUserMap.Translate(subject);
        }

        public SubjectView GetByName(string name)
        {
            var subject = _subjectRepository.GetByName(name);
            return _subjectViewUserMap.Translate(subject);
        }
    }
}
