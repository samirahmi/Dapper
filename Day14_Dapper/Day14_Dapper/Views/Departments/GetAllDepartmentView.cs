using Day14_Dapper.Applications.Departments;
using Day14_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Departments
{
    public class GetAllDepartmentView
    {
        private readonly IDepartmentAppService _deptAppService;
        public GetAllDepartmentView(IDepartmentAppService deptAppService)
        {
            _deptAppService = deptAppService;
        }
        public void DisplayView()
        {
            Console.Clear();

            Console.WriteLine("List Of Department");
            var listDepartment = _deptAppService.GetAllDepartment();

            foreach (var department in listDepartment)
            {
                Console.WriteLine($"{department.DepartmentName} - {department.DivisionName} - " +
                    $"{department.CompanyName} - {department.EmployeeName}");
            }

            Console.ReadKey();
        }
    }
}
