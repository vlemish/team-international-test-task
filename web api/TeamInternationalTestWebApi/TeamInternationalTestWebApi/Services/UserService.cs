using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeamInternationalTestEf.Models;
using TeamInternationalTestEf.Repos;
using TeamInternationalTestWebApi.Models;

namespace TeamInternationalTestWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IRepo<User> _repo;

        private readonly IConfiguration _configuration;


        public UserService(IRepo<User> repo, IConfiguration configuration)
        {
            _repo = repo;
            _configuration = configuration;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = (_repo as UserRepo).GetByUsername(model.Username);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _repo.GetAll();
        }

        public User GetById(int id)
        {
            return _repo.GetOneById(id);
        }

        // helper method

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("secret").Value);

            var claims = new Dictionary<string, object>();
            claims.Add("userId", user.Id);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Claims = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
