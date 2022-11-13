using Dapper;
using DapperEnigmaCamp.Applications.Dto;
using DapperEnigmaCamp.Models;
using DapperEnigmaCamp.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace DapperEnigmaCamp.Applications.Employees
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly string connString =
            @"Server=DESKTOP-QEO3NAA\SQLEXPRESS;Database=ShippingDB;Trusted_Connection=True;";

        public void Delete(Guid Id)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Execute("DELETE FROM Employee WHERE EmployeeId = @Id", new { Id });
                    transaction.Commit();
                }
                catch (DbException dbex)
                {
                    transaction.Rollback();
                }
                connection.Close();
            }
        }

        public List<EmployeeDto> GetAllEmployee()
        {
            List<EmployeeDto> listEmployeeDto = new List<EmployeeDto>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                listEmployeeDto = connection.Query<EmployeeDto>(@"SELECT emp.EmployeeId, emp.EmployeeName, " +
                    "comp.CompanyName, div.DivisionName, dept.DepartmentName FROM employee emp " +
                    "JOIN company comp ON emp.CompanyId = comp.CompanyId " +
                    "JOIN division div ON emp.divisionId = div.divisionId " +
                    "JOIN department dept ON emp.departmentId = dept.departmentId").ToList();
                connection.Close();
            }

            //string jsonString = JsonSerializer.Serialize(listEmployeeDto); // merubah object menjadi JSON
            //Console.WriteLine(jsonString);

            return listEmployeeDto;
        }

        public EmployeeDto GetById(string Id)
        {
            var employeeDto = new EmployeeDto();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var listEmployeeDto = connection.Query<EmployeeDto>(@"SELECT emp.EmployeeId, emp.EmployeeName, " +
                    "comp.CompanyName, div.DivisionName, dept.DepartmentName FROM employee emp" +
                    "JOIN company comp ON emp.CompanyId = comp.CompanyId" +
                    "JOIN division div ON emp.divisionId = div.divisionId" +
                    "JOIN department dept ON emp.departmentId = dept.departmentId" +
                    "WHERE emp.EmployeeId = @Id", new { Id }).ToList();

                employeeDto = listEmployeeDto.FirstOrDefault();
                connection.Close();
            }

            string jsonString = JsonSerializer.Serialize(employeeDto);

            Console.WriteLine(jsonString);

            return employeeDto;
        }

        public Employee GetModelById(string Id)
        {
            var employee = new Employee();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var listEmployee = connection.Query<Employee>(@"SELECT * FROM Employee " +
                    "WHERE EmployeeId = @Id", new { Id }).ToList();

                employee = listEmployee.FirstOrDefault();
                connection.Close();
            }

            return employee;
        }

        public Employee GetSingleById(string Id)
        {
            var employee = new Employee();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                employee = connection.QuerySingle<Employee>(@"SELECT * FROM Employee " +
                    "WHERE EmployeeId = @Id", new { Id });

                connection.Close();
            }

            return employee;
        }

        public void Insert(Employee employee)
        {
            //base.Insert(employee); /// Cara 1
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Execute("INSERT INTO Employee(EmployeeId, EmployeeName, Salary, CompanyId, " +
                        "DivisionId, DepartmentId) VALUES " +
                        "(@EmployeeId, @EmployeeName, @Salary, @CompanyId, " +
                        "@DivisionId, @DepartmentId) ",
                        new
                        {
                            employee.EmployeeId,
                            employee.EmployeeName,
                            employee.Salary,
                            employee.CompanyId,
                            employee.DivisionId,
                            employee.DepartmentId
                        });
                    transaction.Commit();
                }
                catch (DbException dbex)
                {
                    transaction.Rollback();
                }
                connection.Close();
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Execute("UPDATE Employee SET EmployeeName = @EmployeeName, " +
                    "Salary = @Salary, " +
                    "CompanyId = @CompanyId," +
                    "DivisionId = @DivisionId," +
                    "DepartmentId = @DepartmentId " +
                    "WHERE EmployeeId = @EmployeeId ",
                    new
                    {
                        employee.EmployeeId,
                        employee.EmployeeName,
                        employee.Salary,
                        employee.CompanyId,
                        employee.DivisionId,
                        employee.DepartmentId
                    });
                    transaction.Commit();
                }
                catch (DbException dbex)
                {
                    transaction.Rollback();
                }
                connection.Close();
            }
        }
    }
}
