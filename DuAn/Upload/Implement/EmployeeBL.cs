using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload.Interface;

namespace Upload.Implement
{
    public class EmployeeBL: BaseBL, IEmployeeBL
    {
        public EmployeeBL(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
