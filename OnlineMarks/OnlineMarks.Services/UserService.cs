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

        public void Add(string username, string password, string role)
        {   
            (byte[] passwordHash, byte[] passwordSalt) = _authManager.CreatePasswordHashAndSalt(password);

            if(UserRole.Admin == role)
            {
                var user = new Admin() { Name = username, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Id = Guid.NewGuid() };
                _userRepository.Add(user);
            }
            else if(UserRole.Parent == role)
            {
                var user = new Parent() { Name = username, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Id = Guid.NewGuid() };
                _userRepository.Add(user);
            }
            else if (UserRole.Professor == role)
            {
                var user = new Professor() { Name = username, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Id = Guid.NewGuid() };
                _userRepository.Add(user);
            }
            else if (UserRole.Student == role)
            {
                var user = new Student() { Name = username, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Id = Guid.NewGuid() };
                _userRepository.Add(user);
            }
        }

        public UserView Authenticate(AuthenticateModel model) // JWT
        {   
            var user = _userRepository.GetByUsername(model.Username);

            // return null if user not found
            if (user == null)
                return null;            

            if(!_authManager.VerifyPaswordHash(model.Password, user.PasswordSalt, user.PasswordHash))
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
            var user = _userRepository.Get(id);
            return _userViewUserMap.Translate(user);
        }

        public User Get(string name){
            return _userRepository.Get(name);
        }
    }
}
