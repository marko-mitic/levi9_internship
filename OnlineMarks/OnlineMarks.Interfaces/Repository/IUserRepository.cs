using OnlineMarks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User Get(Guid userId);
        User Get(string name);
        List<User> GetAll();
        User GetByUsername(string username);
    }
}
