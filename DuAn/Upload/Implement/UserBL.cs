using Microsoft.AspNetCore.Http;
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
        private readonly IRoleDetailBL _roleDetailBL;

        public UserBL(IConfiguration configuration, IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor, IRoleDetailBL roleDetailBL) : base(configuration, httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _roleDetailBL = roleDetailBL;
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

        public async Task<object> UserInfo()
        {
            Dictionary<string, object> userInfo = new Dictionary<string, object>();
            var user = (User)_httpContextAccessor.HttpContext.Items["User"];
            Employee employee = (Employee)await GetByID<Employee>(user.EmployeeID.ToString(),typeof(Employee),"employee");
            userInfo.Add("EmployeeID", user.EmployeeID);
            userInfo.Add("EmployeeName", employee.EmployeeName);
            userInfo.Add("OrganizationUnitID", user.OrganizationUnitID);
            userInfo.Add("OrganizationUnitName", user.OrganizationUnitName);
            //Lấy ra danh sách quyền
            var listRole = await _roleDetailBL.GetListRoleDetail(user.RoleID.ToString());
            userInfo.Add("ListRole", listRole);
            return userInfo;
        }
    }
}
