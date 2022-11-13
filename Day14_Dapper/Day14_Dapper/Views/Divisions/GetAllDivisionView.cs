using Day14_Dapper.Applications.Divisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Divisions
{
    public class GetAllDivisionView
    {
        private readonly IDivisionAppService _divAppService;

        public GetAllDivisionView(IDivisionAppService divAppService)
        {
            _divAppService = divAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("List Of Division");
            var listDivision = _divAppService.GetAllDivision();

            foreach(var division in listDivision)
            {
                Console.WriteLine($"{division.DivisionName} - {division.DepartmentName} - {division.CompanyName}");
            }

            Console.ReadKey();
        }
    }
}
