using Dapper;
using Day14_Dapper.Applications.Departments.Dto;
using Day14_Dapper.Applications.Divisions.Dto;
using Day14_Dapper.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Applications.Departments
{
    internal class DepartmentAppService : IDepartmentAppService
    {
        private readonly string connString =
            @"Host=localhost;Username=postgres;Password=sami;Database=Gudang;";
        public void Delete(Guid Id)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                connection.Execute("DELETE FROM Department WHERE DepartmentId = @Id", new { Id });
                connection.Close();
            }
        }

        public List<DepartmentDto> GetAllDepartment()
        {
            List<DepartmentDto> listDepartmentDto = new List<DepartmentDto>();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                listDepartmentDto = connection.Query<DepartmentDto>(@"SELECT dept.DepartmentName, div.DivisionName, " +
                    "comp.CompanyName, emp.EmployeeName FROM Department as dept " +
                    "JOIN Division as div ON dept.DivisionId = div.DivisionId " +
                    "JOIN Company as comp ON dept.CompanyId = comp.CompanyId " +
                    "JOIN Employee as emp ON dept.DepartmentId = emp.DepartmentId").ToList();
                connection.Close();
            }
            return listDepartmentDto;
        }

        public DepartmentDto GetById(Guid Id)
        {
            var departmentDto = new DepartmentDto();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                 var listDepartmentDto = connection.Query<DepartmentDto>(@"SELECT dept.DepartmentName, div.DivisionName, " +
                    "comp.CompanyName, emp.EmployeeName FROM Department as dept " +
                    "JOIN Division as div ON dept.DivisionId = div.DivisionId " +
                    "JOIN Company as comp ON dept.CompanyId = comp.CompanyId " +
                    "JOIN Company as comp ON comp.DepartmentId = emp.DepartmentId " +
                    "WHERE dept.DepartmentId = @Id", new { Id }).ToList();

                departmentDto = listDepartmentDto.FirstOrDefault();
                connection.Close();
            }
            return departmentDto;
        }

        public Department GetModelById(Guid Id)
        {
            var department = new Department();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var listDepartment = connection.Query<Department>(@"SELECT * FROM Department" +
                    " WHERE DepartmentId = @Id", new { Id }).ToList();

                department = listDepartment.FirstOrDefault();
                connection.Close();
            }
            return department;
        }

        public void Insert(Department department)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Department (DepartmentId, CompanyId, DivisionId, DepartmentName)" +
                    " VALUES (@DepartmentId, @CompanyId, @DivisionId, @DepartmentName)",
                    new
                    {
                        DepartmentId = department.DepartmentId,
                        CompanyId = department.CompanyId,
                        DivisionId = department.DivisionId,
                        DepartmentName = department.DepartmentName,
                    });
                connection.Close();
            }
        }

        public void Update(Department department)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                connection.Execute("UPDATE Department SET CompanyId = @CompanyId, DivisionId = @DivisionId," +
                    " DepartmentName = @DepartmentName)" +
                    " WHERE DepartmentId = @DepartmentId;",
                    new
                    {
                        department.DepartmentId,
                        department.CompanyId,
                        department.DivisionId,
                        department.DepartmentName,
                    });
                connection.Close();
            }
        }
    }
}
