using Day14_Dapper.Applications.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Models.Views.Employees
{
    public class DeleteEmployeeView
    {
        private readonly IEmployeeAppService _empAppService;

        public DeleteEmployeeView(IEmployeeAppService empAppService)
        {
            _empAppService = empAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Delete Employee");
            Console.WriteLine("----------------");

            Console.Write("Type Employee Id : ");
            var employeeId = Console.ReadLine();
            var resultEmp = _empAppService.GetModelById(Guid.Parse(employeeId));

            if (resultEmp != null)
            {
                Console.WriteLine($"Employee Name : {resultEmp.EmployeeName} ");
                Console.WriteLine($"Salary        : {resultEmp.Salary}");
                Console.WriteLine($"Company       : {resultEmp.CompanyId}");
                Console.WriteLine($"Division      : {resultEmp.DivisionId}");
                Console.WriteLine($"Department    : {resultEmp.DepartmentId}");

                Console.Write("Are you sure want to DELETE this record? (Y/N)");
                var choise = Console.ReadLine();

                if (choise.ToUpper().Equals("Y"))
                {
                    var employee = new Employee();
                    employee.EmployeeId = resultEmp.EmployeeId;
                    employee.EmployeeName = resultEmp.EmployeeName;
                    employee.Salary = resultEmp.Salary;
                    employee.CompanyId = resultEmp.CompanyId;
                    employee.DivisionId = resultEmp.DivisionId;
                    employee.DepartmentId = resultEmp.DepartmentId;

                    _empAppService.Delete(Guid.Parse(employeeId));
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
