using OnlineMarks.Data.Models;
using OnlineMarks.Data.ViewModels.Auth;
using OnlineMarks.Data.ViewModels.Users;
using OnlineMarks.Interfaces.Maps;
using OnlineMarks.Interfaces.Repository;
using OnlineMarks.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineMarks.Tools.Enums;
using OnlineMarks.Tools.Auth;


namespace OnlineMarks.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserViewUserMap _userViewUserMap;

        private readonly IAuthManager _authManager;

        public UserService(IUserRepository userRepository, IUserViewUserMap userViewUserMap, IAuthManager authManager)
        {
            _userRepository = userRepository;
            _userViewUserMap = userViewUserMap;
            _authManager = authManager;
        }

        public User Add(string username, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException($"{nameof(username)} is empty");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException($"{nameof(password)} is empty");
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentNullException($"{nameof(role)} is empty");
            }

            (byte[] passwordHash, byte[] passwordSalt) = _authManager.CreatePasswordHashAndSalt(password); // help

            if (UserRole.Admin == role)
            {
                var user = new Admin() { Name = username, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Id = Guid.NewGuid() };
                _userRepository.Add(user);
                return user;
            }
            else if (UserRole.Parent == role)
            {
                var user = new Parent() { Name = username, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Id = Guid.NewGuid() };
                _userRepository.Add(user);
                return user;
            }
            else if (UserRole.Professor == role)
            {
                var user = new Professor() { Name = username, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Id = Guid.NewGuid() };
                _userRepository.Add(user);
                return user;
            }
            else if (UserRole.Student == role)
            {
                var user = new Student() { Name = username, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Id = Guid.NewGuid() };
                _userRepository.Add(user);
                return user;
            }
            else
            {
                throw new ArgumentNullException($"{nameof(role)} was not set properly");
            }
        }

        public UserView Authenticate(AuthenticateModel model) // JWT
        {
            if(model == null)
            {
                throw new ArgumentNullException($"{nameof(model)} is empty");
            }

            if (string.IsNullOrWhiteSpace(model.Username))
            {
                throw new ArgumentNullException($"{nameof(model.Username)} is empty");
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                throw new ArgumentNullException($"{nameof(model.Password)} is empty");
            }

            if (string.IsNullOrWhiteSpace(model.Role))
            {
                throw new ArgumentNullException($"{nameof(model.Role)} is empty");
            }

            var user = _userRepository.GetByUsername(model.Username);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with name {user} not found");
            }

            if (!_authManager.VerifyPaswordHash(model.Password, user.PasswordSalt, user.PasswordHash)) // password not good
                return null;

            var userModel = _userViewUserMap.Translate(user);

            userModel.Token = _authManager.GenerateToken(user.Id.ToString(), user.Role);

            return userModel;
        }

        public IEnumerable<UserView> GetAll() // ExtensionMethods where added here
        {
            var userList = _userRepository.GetAll();
            return _userViewUserMap.Translate(userList);
        }

        public UserView GetById(Guid id) // ExtensionMethods where added here
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new ArgumentNullException($"{nameof(id)} is empty");
            }

            var user = _userRepository.Get(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with name {user} not found");
            }
            return _userViewUserMap.Translate(user);
        }
    }
}
