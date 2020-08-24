using OnlineMarks.Data.Models;
using OnlineMarks.Data.Models.Context;
using OnlineMarks.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMarks.Data.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ProfessorRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public Professor GetByName(string name)
        {
            return _applicationContext.Professors.FirstOrDefault(x => x.Name == name);
        }
    }
}
