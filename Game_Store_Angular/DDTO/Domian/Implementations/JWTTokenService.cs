using Game_Store_Angular.DDTO.DataAccess;
using Game_Store_Angular.DDTO.DataAccess.Entity;
using Game_Store_Angular.DDTO.Domian.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store_Angular.DDTO.Domian.Implementations
{
    public class JWTTokenService : IJWTTokenService
    {
        private readonly EFContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;



        public JWTTokenService(
        EFContext context,
        IConfiguration configuration,
        UserManager<User> userManager)
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
        }



        public string CreateToken(User user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
            {
                new Claim("id", user.Id),
                new Claim("email", user.Email)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }

            string jwtTokenSecretKey = _configuration["SecretPhrase"];
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenSecretKey));
            var signInCreadentions = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                signingCredentials: signInCreadentions,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(14)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
