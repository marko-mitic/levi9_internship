using Microsoft.EntityFrameworkCore;
using OnlineMarks.Data.Models;
using OnlineMarks.Data.Models.Context;
using OnlineMarks.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMarks.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _applicationContext;
        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Add(User user)
        {
            _applicationContext.Users.Add(user);
            _applicationContext.SaveChanges();
        }

        public User GetByUsername(string username)
        {
            return _applicationContext.Users.FirstOrDefault(x => x.Name == username);
        }

        public User Get(Guid userId)
        {
            return _applicationContext.Users.FirstOrDefault(x => x.Id == userId);
        }

        public List<User> GetAll()
        {
            return _applicationContext.Users.ToList();
        }
    }
}
