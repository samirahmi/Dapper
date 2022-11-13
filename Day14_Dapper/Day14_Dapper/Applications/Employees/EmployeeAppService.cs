using Dapper;
using Day14_Dapper.Applications.Divisions;
using Day14_Dapper.Applications.Employees.Dto;
using Day14_Dapper.BaseRepositorys;
using Day14_Dapper.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Applications.Employees
{
    internal class EmployeeAppService : IEmployeeAppService
    {
        private readonly string connString =
            @"Host=localhost;Username=postgres;Password=sami;Database=Gudang;";
        public void Delete(Guid Id)
        {
            
            using (var connection = new NpgsqlConnection(connString))
            {
                //Using Transaction
                //connection.Open();
                //var transaction = connection.BeginTransaction();
                //try
                //{
                //    connection.Execute("DELETE FROM Employee WHERE EmployeeId = @Id", new { Id });
                //    transaction.Commit();
                //}
                //catch
                //{
                //    transaction.Rollback();
                //}

                ////NOT USING TRANSACTION
                connection.Open();
                connection.Execute("DELETE FROM Employee WHERE EmployeeId = @Id", new { Id = Id });
                connection.Close();
            }
        }

        public List<EmployeeDto> GetAllEmployee()
        {
            List<EmployeeDto> listEmployeeDto = new List<EmployeeDto>();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                listEmployeeDto = connection.Query<EmployeeDto>(@"SELECT emp.EmployeeId, emp.EmployeeName, " +
                    "comp.CompanyName, div.DivisionName, dept. DepartmentName FROM Employee as emp " +
                    "JOIN company as comp ON emp.CompanyId = comp.CompanyId " +
                    "JOIN division as div ON emp.DivisionId = div.DivisionId " +
                    "JOIN department as dept ON emp.DepartmentId = dept.DepartmentId").ToList();
                connection.Close();
            }
            return listEmployeeDto;
        }

        public EmployeeDto GetById(Guid Id)
        {
            var employeeDto = new EmployeeDto();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var listEmployeeDto = connection.Query<EmployeeDto>(@"SELECT emp.EmployeeId, emp.EmployeeName, " +
                    "comp.CompanyName, div.DivisionName, dept. DepartmentName FROM Employee as emp " +
                    "JOIN company as comp ON emp.CompanyId = comp.CompanyId " +
                    "JOIN division as div ON emp.DivisionId = div.DivisionId " +
                    "JOIN department as dept ON emp.DepartmentId = dept.DepartmentId " +
                    "WHERE emp.EmployeeId = @Id", new { Id }).ToList();

                employeeDto = listEmployeeDto.FirstOrDefault();
                connection.Close();
            }
            return employeeDto;
        }

        public Employee GetModelById(Guid Id)
        {
            var employee = new Employee();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var listEmployee = connection.Query<Employee>(@"SELECT * FROM Employee" +
                    " WHERE EmployeeId = @Id", new { Id }).ToList();

                employee = listEmployee.FirstOrDefault();
                connection.Close();
            }
            return employee;
        }

        public Employee GetSingleById(string Id)
        {
            var employee = new Employee();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                employee = connection.QuerySingle<Employee>(@"SELECT * FROM Employee " +
                    "WHERE EmployeeeId = @Id", new { Id });
                connection.Close();
            }
            return employee;
        }

        public void Insert(Employee employee)
        {
            //Cara 1 = menggunakan BASEREPOSITORY
            //base.Insert(employee);

            //Cara 2
            using (var connection = new NpgsqlConnection(connString))
            {
                // using transaction
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Execute("INSERT INTO Employee (EmployeeId, EmployeeName, Salary, CompanyId, " +
                    " DivisionId, DepartmentId)" +
                    " VALUES (@EmployeeId, @EmployeeName, @Salary, @CompanyId, @DivisionId, @DepartmentId)",
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

                //connection.Open();
                //connection.Execute("INSERT INTO Employee (EmployeeId, EmployeeName, Salary, CompanyId, " +
                //    " DivisionId, DepartmentId)" +
                //    " VALUES (@EmployeeId, @EmployeeName, @Salary, @CompanyId, @DivisionId, @DepartmentId)",
                //    new
                //    {
                //        EmployeeId = employee.EmployeeId,
                //        EmployeeName = employee.EmployeeName,
                //        Salary = employee.Salary,
                //        CompanyId = employee.CompanyId,
                //        DivisionId = employee.DivisionId,
                //        DepartmentId = employee.DepartmentId
                //    });
                connection.Close();
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                //Using Transaction
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    connection.Execute("UPDATE Employee SET EmployeeName = @EmployeeName," +
                    " Salary = @Salary," +
                    " CompanyId = @CompanyId," +
                    " DivisionId = @DivisionId," +
                    " DepartmentId = @DepartmentId" +
                    " WHERE EmployeeId = @EmployeeId",
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

                ////Not Using Transaction
                //connection.Open();
                //connection.Execute("UPDATE Employee SET EmployeeName = @EmployeeName," +
                //    " Salary = @Salary" +
                //    " CompanyId = @CompanyId" +
                //    " DivisionId = @DivisionId" +
                //    " DepartmentId = @DepartmentId" +
                //    " WHERE EmployeeId = @EmployeeId",
                //    new
                //    {
                //        EmployeeId = employee.EmployeeId,
                //        EmployeeName = employee.EmployeeName,
                //        Salary = employee.Salary,
                //        CompanyId = employee.CompanyId,
                //        DivisionId = employee.DivisionId,
                //        DepartmentId = employee.DepartmentId
                //    });
                connection.Close();
            }
        }
    }
}
