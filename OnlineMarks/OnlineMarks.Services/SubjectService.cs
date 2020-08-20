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
        public void Add(string name, string professorName)
        {
            var professor = _professorRepository.GetByName(professorName);

            var subject = new Subject() { Name = name, Id = Guid.NewGuid(), Professor = professor };
            _subjectRepository.Add(subject);
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
            var subject = _subjectRepository.GetByUsername(name);
            return _subjectViewUserMap.Translate(subject);
        }
    }
}
