using DapperEnigmaCamp.Applications.Employees;
using DapperEnigmaCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperEnigmaCamp.Views.Employees
{
    public class CreateEmployeeView
    {
        private readonly IEmployeeAppService _empAppService;
        public CreateEmployeeView(IEmployeeAppService empAppService)
        {
            _empAppService = empAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Create Employee");
            Console.WriteLine("-----------------");

            Console.Write("Employee Name : ");
            var empName = Console.ReadLine();
            Console.Write("Salary : ");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Company : ");
            string companyId = Console.ReadLine();
            Console.Write("Division : ");
            string divisionId = Console.ReadLine();
            Console.Write("Department : ");
            string departmentId = Console.ReadLine();

            var employee = new Employee();
            Guid guid = Guid.NewGuid();
            employee.EmployeeId = guid;
            employee.EmployeeName = empName;
            employee.Salary = salary;
            employee.CompanyId = Guid.Parse(companyId);
            employee.DivisionId = Guid.Parse(divisionId);
            employee.DepartmentId = Guid.Parse(departmentId);

            _empAppService.Insert(employee);
        }
    }
}
