using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid DivisionId { get; set; }
        public string DepartmentName { get; set; }
    }
}
