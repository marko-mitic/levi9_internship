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

        public SubjectService(ISubjectRepository subjectRepository, ISubjectViewSubjectMap subjectViewUserMap, IProfessorRepository professorRepository)
        {
            _subjectRepository = subjectRepository;
            _subjectViewUserMap = subjectViewUserMap;
            _professorRepository = professorRepository;
        }
        public Subject Add(string name, string professorName)
        {
            if (name == null)
                throw new ArgumentNullException(name);
            if (name == "")
                throw new ArgumentOutOfRangeException(name);
            if (professorName == null)
                throw new ArgumentNullException(professorName);
            if (professorName == "")
                throw new ArgumentOutOfRangeException(professorName);

            var professor = _professorRepository.GetByName(professorName);

            if (professor == null)
                return null;

            var subject = new Subject() { Name = name, Id = Guid.NewGuid(), Professor = professor };
            _subjectRepository.Add(subject);

            return subject;
        }

        public IEnumerable<SubjectView> GetAll()
        {
            var subjectList = _subjectRepository.GetAll();
            return _subjectViewUserMap.Translate(subjectList);
        }

        public SubjectView GetById(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException(id.ToString());

            var subject = _subjectRepository.Get(id);

            if (subject == null)
                return null;

            return _subjectViewUserMap.Translate(subject);
        }

        public SubjectView GetByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(name);
            if (name == "")
                throw new ArgumentOutOfRangeException(name);

            var subject = _subjectRepository.GetByUsername(name);

            if (subject == null)
                return null;

            return _subjectViewUserMap.Translate(subject);
        }
    }
}
