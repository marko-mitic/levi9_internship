using OnlineMarks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Repository
{
    public interface ISubjectRepository
    {
        void Add(Subject subject);
        Subject Get(Guid subjectId);
        List<Subject> GetAll();
        Subject GetByUsername(string name);
    }
}
