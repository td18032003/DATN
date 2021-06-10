using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload.Interface;
using Upload.Models;

namespace Upload.Implement
{
    public class RoleDetailBL: BaseBL, IRoleDetailBL
    {
        public RoleDetailBL(IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(configuration, httpContextAccessor)
        {

        }

        public async Task<object> GetListRoleDetail(string id)
        {
            string sql = $"SELECT * FROM role_detail WHERE RoleID = {id};";
            var res = await QueryCommandTexListtAsync<RoleDetail>(sql);
            return res;
        }
    }
}
