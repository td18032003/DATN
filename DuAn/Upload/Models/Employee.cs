using System;
using System.Collections.Generic;
using System.Text;

namespace Upload
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string EmployeeCode { get; set; }

        public string EmployeeName { get; set; }

        public DateTime BirthDay { get; set; }

        public string Gender { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int OrganizationUnitID { get; set; }

        public string OrganizationUnitName { get; set; }

        public int JobPoisionID { get; set; }

        public string JobPoisitionName { get; set; }

        public int Status { get; set; }

        public string TenantID { get; set; }
    }
}
