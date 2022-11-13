using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Applications.Employees.Dto
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public string DivisionName { get; set; }
        public string DepartmentName { get; set; }
    }
}
