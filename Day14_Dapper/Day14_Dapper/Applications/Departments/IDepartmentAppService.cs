using Day14_Dapper.Applications.Departments.Dto;
using Day14_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Applications.Departments
{
    public interface IDepartmentAppService
    {
        void Insert(Department department);
        void Delete(Guid Id);
        void Update(Department department);
        List<DepartmentDto> GetAllDepartment();
        DepartmentDto GetById(Guid Id);
        Department GetModelById(Guid Id);
    }
}
