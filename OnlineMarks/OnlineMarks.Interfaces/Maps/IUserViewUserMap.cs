using OnlineMarks.Data.Models;
using OnlineMarks.Data.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Interfaces.Maps
{
    public interface IUserViewUserMap
    {
        UserView Translate(User user);
        IEnumerable<UserView> Translate(IEnumerable<User> user);
    }
}
