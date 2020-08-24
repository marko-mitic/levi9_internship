using Microsoft.EntityFrameworkCore;
using OnlineMarks.Data.Models;
using OnlineMarks.Data.Models.Context;
using OnlineMarks.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMarks.Data.Repositories
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        private readonly ApplicationContext _applicationContext;
        public StudentSubjectRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public List<StudentSubject> GetAll(Guid subjectId)
        {
            return _applicationContext.StudentSubjects.Include(x => x.Student).Where(x => x.SubjectId == subjectId).ToList();
        }
    }
}
