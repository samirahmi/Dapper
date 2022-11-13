using DapperEnigmaCamp.Applications.Dto;
using DapperEnigmaCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEnigmaCamp.Applications.Employees
{
    public interface IEmployeeAppService
    {
        void Insert(Employee employee);
        void Delete(Guid Id);
        void Update(Employee employee);
        List<EmployeeDto> GetAllEmployee();
        EmployeeDto GetById(string Id);
        Employee GetModelById(string Id);
    }
}
