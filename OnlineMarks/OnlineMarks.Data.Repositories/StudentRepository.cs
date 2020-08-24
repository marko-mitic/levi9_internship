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
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _applicationContext;
        public StudentRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public Student GetByName(string name)
        {
            return _applicationContext.Students.FirstOrDefault(x => x.Name == name);
        }
    }
}
