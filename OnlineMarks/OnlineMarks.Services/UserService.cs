using OnlineMarks.Data.Models;
using OnlineMarks.Data.Repositories;
using OnlineMarks.Data.ViewModels.Users;
using OnlineMarks.Interfaces.Maps;
using OnlineMarks.Interfaces.Repository;
using OnlineMarks.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMarks.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserViewUserMap _userViewUserMap;

        public UserService(IUserRepository userRepository, IUserViewUserMap userViewUserMap)
        {
            _userRepository = userRepository;
            _userViewUserMap = userViewUserMap;
        }
        public User Authenticate(string username, string password) // JWT
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserView> GetAll() // ExtensionMethods where added here
        {
            //var userList = _userRepository.GetAll();
            throw new NotImplementedException();
            //return _userViewUserMap.Translate(userList);
        }

        public UserView GetById(Guid id) // ExtensionMethods where added here
        {
            //var user = _userRepository.Get(id);
            throw new NotImplementedException();
            //return _userViewUserMap.Translate(user);
        }
    }
}
