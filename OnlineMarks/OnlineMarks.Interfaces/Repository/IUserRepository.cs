using OnlineMarks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User Get(string userId);
        List<User> GetAll();
    }
}
