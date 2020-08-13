using OnlineMarks.Data.Models;
using OnlineMarks.Data.ViewModels.Auth;
using OnlineMarks.Data.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Services
{
    public interface IUserService
    {
        UserView Authenticate(AutheticateModel model);
        IEnumerable<UserView> GetAll();
        UserView GetById(Guid id);
    }
}
