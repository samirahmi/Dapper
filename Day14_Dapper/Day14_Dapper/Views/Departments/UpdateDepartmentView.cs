using Day14_Dapper.Applications.Departments;
using Day14_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Departments
{
    public class UpdateDepartmentView
    {
        private readonly IDepartmentAppService _deptAppService;
        public UpdateDepartmentView(IDepartmentAppService deptAppService)
        {
            _deptAppService = deptAppService;
        }
        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Update Department");
            Console.WriteLine("-----------------");

            Console.Write("Type Department Id : ");
            var departmentId = Console.ReadLine();
            var resultDept = _deptAppService.GetModelById(Guid.Parse(departmentId));

            if (resultDept != null)
            {
                Console.WriteLine($"Company       : {resultDept.CompanyId}");
                Console.WriteLine($"Division      : {resultDept.DivisionId}");
                Console.WriteLine($"Department    : {resultDept.DepartmentName}");

                Console.Write("Are you sure want to DELETE this record? (Y/N) = ");
                var choise = Console.ReadLine();

                if (choise.ToUpper().Equals("Y"))
                {
                    Console.Write("Company Id           : ");
                    string companyId = Console.ReadLine();
                    Console.Write("Division Id          : ");
                    string divisionId = Console.ReadLine();
                    Console.Write("Department Name      : ");
                    string deptName = Console.ReadLine();

                    var department = new Department();
                    Guid guid = Guid.NewGuid();
                    department.DepartmentId = resultDept.DepartmentId;
                    department.CompanyId = Guid.Parse(companyId);
                    department.DivisionId = Guid.Parse(divisionId);
                    department.DepartmentName = resultDept.DepartmentName;

                    _deptAppService.Update(department);
                }
            }
            else
            {
                Console.WriteLine("Data Not Found!");
                Console.ReadKey();
            }
        }
    }
}
