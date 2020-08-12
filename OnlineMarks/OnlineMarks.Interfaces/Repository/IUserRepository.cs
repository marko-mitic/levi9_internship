using OnlineMarks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Repository
{
    public interface IUserRepository
    {
        User Add(User user);

        User Get(string username);
    }
}
