using OnlineMarks.Data.Models;
using OnlineMarks.Data.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<UserView> GetAll();
        UserView GetById(Guid id);
    }
}
