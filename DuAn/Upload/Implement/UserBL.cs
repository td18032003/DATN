using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Upload.Interface;
using Upload.Models;

namespace Upload.Implement
{
    public class UserBL : BaseBL, IUserBL
    {
        private readonly AppSettings _appSettings;

        public UserBL(IConfiguration configuration, IOptions<AppSettings> appSettings) : base(configuration)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            //Kiểm tra dưới database có tài khoản này không
            string sql = $"SELECT * FROM user WHERE (Email = '{model.Username}' OR Phone = '{model.Username}') AND Password = {model.Password}";
            var res = await QueryCommandTextAsync<User>(sql);

            // return null if user not found
            if (res == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken((User)res);

            return new AuthenticateResponse((User)res, token);
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserID", user.UserID.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
