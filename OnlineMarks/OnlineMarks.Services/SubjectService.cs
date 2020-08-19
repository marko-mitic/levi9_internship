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

        public SubjectService(ISubjectRepository subjectRepository, ISubjectViewSubjectMap subjectViewUserMap)
        {
            _subjectRepository = subjectRepository;
            _subjectViewUserMap = subjectViewUserMap;
        }
        public void Add(string name)
        {
            var subject = new Subject() { Name = name, Id = Guid.NewGuid() };
            _subjectRepository.Add(subject);
        }

        public IEnumerable<SubjectView> GetAll()
        {
            var userList = _subjectRepository.GetAll();
            return _subjectViewUserMap.Translate(userList);
        }

        public SubjectView GetById(Guid id)
        {
            var user = _subjectRepository.Get(id);
            return _subjectViewUserMap.Translate(user);
        }
    }
}
