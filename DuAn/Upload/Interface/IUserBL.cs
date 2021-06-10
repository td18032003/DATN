using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload.Models;

namespace Upload.Interface
{
    public interface IUserBL : IBaseBL
    {
        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}
