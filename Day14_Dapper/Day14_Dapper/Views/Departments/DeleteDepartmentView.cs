using Day14_Dapper.Applications.Departments;
using Day14_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Departments
{
    public class DeleteDepartmentView
    {
        private readonly IDepartmentAppService _deptAppService;
        public DeleteDepartmentView(IDepartmentAppService deptAppService)
        {
            _deptAppService = deptAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Delete Department");
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
                    var department = new Department();
                    department.DepartmentId = resultDept.DepartmentId;
                    department.CompanyId = resultDept.CompanyId;
                    department.DivisionId = resultDept.DivisionId;
                    department.DepartmentName = resultDept.DepartmentName;

                    _deptAppService.Delete(Guid.Parse(departmentId));
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
