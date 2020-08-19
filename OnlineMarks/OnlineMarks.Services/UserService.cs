using Microsoft.IdentityModel.Tokens;
using OnlineMarks.Data.Models;
using OnlineMarks.Data.Repositories;
using OnlineMarks.Data.ViewModels.Auth;
using OnlineMarks.Data.ViewModels.Users;
using OnlineMarks.Interfaces.Maps;
using OnlineMarks.Interfaces.Repository;
using OnlineMarks.Interfaces.Services;
using OnlineMarks.Tools.ConfigurationObjects;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace OnlineMarks.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserViewUserMap _userViewUserMap;

        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IUserViewUserMap userViewUserMap, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _userViewUserMap = userViewUserMap;
            _configuration = configuration;
        }

        public UserView Authenticate(AuthenticateModel model) // JWT
        {
            var user = _userRepository.Authenticate(model.Username, model.Password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                  new Claim(ClaimTypes.Name, user.Id.ToString()),
                  new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userModel = _userViewUserMap.Translate(user);

            userModel.Token = tokenHandler.WriteToken(token);

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
    }
}
