using OnlineMarks.Data.Models;
using OnlineMarks.Data.Repositories;
using OnlineMarks.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace OnlineMarks.Services
{
    public class UserServices : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Authenticate(string username, string password) // JWT
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll(); // ExtensionMethods where added here
        }

        public User GetById(string id)
        {
            return _userRepository.Get(id); // ExtensionMethods where added here
        }
    }
}
