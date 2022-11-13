using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
        public Guid CompanyId { get; set; }
        public Guid DivisionId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
