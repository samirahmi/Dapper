using Day14_Dapper.Applications.Employees.Dto;
using Day14_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Applications.Employees
{
    public interface IEmployeeAppService
    {
        void Insert(Employee employee);
        void Delete(Guid Id);
        void Update(Employee employee);
        List<EmployeeDto> GetAllEmployee();
        EmployeeDto GetById(Guid Id);
        Employee GetModelById(Guid Id);
    }
}
