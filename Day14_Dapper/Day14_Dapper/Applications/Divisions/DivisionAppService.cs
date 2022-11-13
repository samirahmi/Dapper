using Dapper;
using Day14_Dapper.Applications.Divisions.Dto;
using Day14_Dapper.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Applications.Divisions
{
    internal class DivisionAppService : IDivisionAppService
    {
        private readonly string connString =
            @"Host=localhost;Username=postgres;Password=sami;Database=Gudang;";
        public void Delete(Guid Id)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                connection.Execute("DELETE FROM Division WHERE DivisionId = @Id", new { Id });
                connection.Close();
            }
        }

        public List<DivisionDto> GetAllDivision()
        {
            List<DivisionDto> listDivisionDto = new List<DivisionDto>();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                listDivisionDto = connection.Query<DivisionDto>(@"SELECT div.DivisionName, " +
                    "dept.DepartmentName, comp.CompanyName FROM Division as div " +
                    "JOIN Department as dept ON dept.DivisionId = div.DivisionId " +
                    "JOIN Company as comp ON div.CompanyId = comp.CompanyId").ToList();
                connection.Close();
            }
            return listDivisionDto;
        }

        public DivisionDto GetById(Guid Id)
        {
            var divisionDto = new DivisionDto();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var listDivisionDto = connection.Query<DivisionDto>(@"SELECT div.DivisionName, " +
                    "dept.DepartmentName, comp.CompanyName FROM Division as div " +
                    "JOIN Department as dept ON dept.DivisionId = div.DivisionId " +
                    "JOIN Company as comp ON div.CompanyId = comp.CompanyId " +
                    "WHERE emp.DivisionId = @Id", new { Id }).ToList();

                divisionDto = listDivisionDto.FirstOrDefault();
                connection.Close();
            }
            return divisionDto;
        }

        public Division GetModelById(Guid Id)
        {
            var division = new Division();
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                var listDivision = connection.Query<Division>(@"SELECT * FROM Division" +
                    " WHERE EmployeeId = @Id", new { Id }).ToList();

                division = listDivision.FirstOrDefault();
                connection.Close();
            }
            return division;
        }

        public void Insert(Division division)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Division (DivisionId, CompanyId, DivisionName)" +
                    " VALUES (@DivisionId, @CompanyId, @DivisionName)",
                    new
                    {
                        DivisionId = division.DivisionId,
                        CompanyId = division.CompanyId,
                        DivisionName = division.DivisionName,
                    });
                connection.Close();
            }
        }

        public void Update(Division division)
        {
            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();
                connection.Execute("UPDATE Division SET CompanyId =  @CompanyId," +
                    " DivisionName = @DivisionName)" +
                    " WHERE DivisionId = @DivisionId;",
                    new
                    {
                        division.DivisionId,
                        division.CompanyId,
                        division.DivisionName,
                    });
                connection.Close();
            }
        }

    }
}
