using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using yedihisse.Business.Utilities.Security.Token.Abstract;
using yedihisse.Entities.Dtos;

namespace yedihisse.Business.Utilities.Security.Token.Concrete
{
    public class TokenManager : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenManager(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateToken(UserLoggedinDto userLoggedinDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimList = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userLoggedinDto.UserPhoneNumber),
                new Claim(ClaimTypes.NameIdentifier, userLoggedinDto.Id.ToString()),
                new Claim(ClaimTypes.Email, userLoggedinDto.EmailAddress),
                new Claim(ClaimTypes.GivenName, userLoggedinDto.FirstName),
                new Claim(ClaimTypes.Surname, userLoggedinDto.LastName),
            };

            foreach (var item in userLoggedinDto.UserJoinTypes)
            {
                claimList.Add(new Claim(ClaimTypes.Role, item.UserType.UserTypeName));
            }

            var claims = claimList.ToArray();

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserLoggedinDto DecodeToken()
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userclaims = identity.Claims;

                return new UserLoggedinDto
                {
                    Id = Convert.ToInt32(userclaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value),
                    UserPhoneNumber = userclaims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value,
                    FirstName = userclaims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userclaims.FirstOrDefault(u => u.Type == ClaimTypes.Surname)?.Value
                };
            }

            return null;
        }
    }
}
