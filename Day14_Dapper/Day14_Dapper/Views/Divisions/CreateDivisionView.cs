using Day14_Dapper.Applications.Divisions;
using Day14_Dapper.Applications.Employees;
using Day14_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Divisions
{
    public class CreateDivisionView
    {
        private readonly IDivisionAppService _divAppService;
        public CreateDivisionView(IDivisionAppService divAppService)
        {
            _divAppService = divAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Create Division");
            Console.WriteLine("----------------");

            Console.Write("Company       : ");
            string companyId = Console.ReadLine();
            Console.Write("Division Name      : ");
            string divName = Console.ReadLine();

            var division = new Division();
            Guid guid = Guid.NewGuid();
            division.DivisionId = guid;
            division.CompanyId = Guid.Parse(companyId);
            division.DivisionName = divName;

            _divAppService.Insert(division);
        }
    }
}
