using OnlineMarks.Data.Models;
using OnlineMarks.Data.ViewModels.Subjects;
using OnlineMarks.Interfaces.Maps;
using OnlineMarks.Interfaces.Repository;
using OnlineMarks.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMarks.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISubjectViewSubjectMap _subjectViewUserMap;
        private readonly IProfessorRepository _professorRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentSubjectRepository _studentSubjectRepository;

        public SubjectService(ISubjectRepository subjectRepository, ISubjectViewSubjectMap subjectViewUserMap,
            IProfessorRepository professorRepository, IStudentRepository studentRepository, IStudentSubjectRepository studentSubjectRepository)
        {
            _subjectRepository = subjectRepository;
            _subjectViewUserMap = subjectViewUserMap;
            _professorRepository = professorRepository;
            _studentRepository = studentRepository;
            _studentSubjectRepository = studentSubjectRepository;
        }
        public void Add(string subjectName, string professorName)
        {
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                throw new ArgumentNullException($"{nameof(subjectName)} is empty");
            }

            if (string.IsNullOrWhiteSpace(professorName))
            {
                throw new ArgumentNullException($"{nameof(professorName)} is empty");
            }

            var professor = _professorRepository.GetByName(professorName);

            if(professor == null)
            {
                throw new KeyNotFoundException($"Professor with name {professorName} not found");
            }

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
            subjectList.ForEach(x => x.StudentSubjects = _studentSubjectRepository.GetAll(x.Id));

            return _subjectViewUserMap.Translate(subjectList);
        }

        public SubjectView GetById(Guid id)
        {
            var subject = _subjectRepository.Get(id);
            subject.StudentSubjects = _studentSubjectRepository.GetAll(subject.Id);

            return _subjectViewUserMap.Translate(subject);
        }

        public SubjectView GetByName(string name)
        {
            var subject = _subjectRepository.GetByName(name);
            subject.StudentSubjects = _studentSubjectRepository.GetAll(subject.Id);

            return _subjectViewUserMap.Translate(subject);
        }
    }
}
