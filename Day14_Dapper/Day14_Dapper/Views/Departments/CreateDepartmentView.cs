using Day14_Dapper.Applications.Departments;
using Day14_Dapper.Applications.Divisions;
using Day14_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Departments
{
    public class CreateDepartmentView
    {
        private readonly IDepartmentAppService _deptAppService;
        public CreateDepartmentView(IDepartmentAppService deptAppService)
        {
            _deptAppService = deptAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Create Department");
            Console.WriteLine("-----------------");

            Console.Write("Company Id           : ");
            string companyId = Console.ReadLine();
            Console.Write("Division Id          : ");
            string divisionId = Console.ReadLine();
            Console.Write("Department Name      : ");
            string deptName = Console.ReadLine();

            var department = new Department();
            Guid guid = Guid.NewGuid();
            department.DepartmentId = guid;
            department.CompanyId = Guid.Parse(companyId);
            department.DivisionId = Guid.Parse(divisionId);
            department.DepartmentName = deptName;

            _deptAppService.Insert(department);
        }
    }
}
