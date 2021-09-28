using BookSharing.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookSharing.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly BookSharingContext _context;
        private readonly AppSettings _appSettings;

        public AuthenticateService(BookSharingContext context,AppSettings appSettings)
        {
            _context = context;
            _appSettings = appSettings;
        }
        public User Authenticate(string UserName, string Password)
        {
            var user = _context.Users.SingleOrDefault(user => user.UserName == UserName && user.UserPassword == Password);
                //users.SingleOrDefault(x => x.Uname == Uname && x.Password == Password);

            //return null if not found
            if (user == null)
                return null;

            //user if found
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.UserPassword = null;
            return user;
        }
    }
}
