using Day14_Dapper.Applications.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Models.Views.Employees
{
    public class UpdateEmployeeView
    {
        private readonly IEmployeeAppService _empAppService;
        public UpdateEmployeeView(IEmployeeAppService empAppService)
        {
            _empAppService = empAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Update Employee");
            Console.WriteLine("----------------");

            Console.Write("Type Employee Id : ");
            var employeeId = Console.ReadLine();
            var resultEmp = _empAppService.GetModelById(Guid.Parse(employeeId));


            if(resultEmp != null)
            {
                Console.WriteLine($"Employee Name : {resultEmp.EmployeeName} ");
                Console.WriteLine($"Salary        : {resultEmp.Salary}");
                Console.WriteLine($"Company       : {resultEmp.CompanyId}");
                Console.WriteLine($"Division      : {resultEmp.DivisionId}");
                Console.WriteLine($"Department    : {resultEmp.DepartmentId}");

                Console.Write("Are you sure want to UPDATE this record? (Y/N)");
                var choise = Console.ReadLine();

                if (choise.ToUpper().Equals("Y"))
                {
                    Console.Write("Employee Name : ");
                    var empName = Console.ReadLine();
                    Console.Write("Salary        : ");
                    int salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Company       : ");
                    string companyId = Console.ReadLine();
                    Console.Write("Division      : ");
                    string divisionId = Console.ReadLine();
                    Console.Write("Department    : ");
                    string departmentId = Console.ReadLine();

                    var employee = new Employee();
                    Guid guid = Guid.NewGuid();
                    employee.EmployeeId = resultEmp.EmployeeId;
                    employee.EmployeeName = empName;
                    employee.Salary = salary;
                    employee.CompanyId = Guid.Parse(companyId);
                    employee.DivisionId = Guid.Parse(divisionId);
                    employee.DepartmentId = Guid.Parse(departmentId);

                    _empAppService.Update(employee);
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
