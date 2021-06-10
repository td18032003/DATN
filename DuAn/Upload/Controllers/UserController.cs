using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload.Entity;
using Upload.Interface;
using Upload.Models;

namespace Upload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        public UserController(IUserBL userBL, IBaseBL baseBL) : base(baseBL)
        {
            baseBL.SetTableName("user");
            this.BL = userBL;
            this.curentType = typeof(User);
        }

        [HttpPost("authenticate")]
        public async Task<object> Authenticate([FromBody]AuthenticateRequest model)
        {
            var response = await (this.BL as IUserBL).Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpGet("user-info")]
        [Models.Authorize]
        public async Task<ServiceResponse> UserInfo()
        {
            ServiceResponse res = new ServiceResponse() { };
            try
            {
                res.Data = await (this.BL as IUserBL).UserInfo();
            }
            catch (Exception ex)
            {
                return _baseBL.Error(ex);
            }
            return res;
        }
    }
}
