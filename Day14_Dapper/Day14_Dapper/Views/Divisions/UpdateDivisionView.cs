using Day14_Dapper.Applications.Divisions;
using Day14_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Divisions
{
    public class UpdateDivisionView
    {
        private readonly IDivisionAppService _divAppService;

        public UpdateDivisionView(IDivisionAppService divAppService)
        {
            _divAppService = divAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Update Division");
            Console.WriteLine("----------------");

            Console.Write("Type Division Id : ");
            var divisionId = Console.ReadLine();
            var resultDiv = _divAppService.GetModelById(Guid.Parse(divisionId));

            if (resultDiv != null)
            {
                Console.WriteLine($"Company       : {resultDiv.CompanyId}");
                Console.WriteLine($"Division Name : {resultDiv.DivisionName}");

                Console.Write("Are you sure want to UPDATE this record? (Y/N)");
                var choise = Console.ReadLine();

                if(choise.ToUpper().Equals("Y"))
                {
                    Console.Write("Company       : ");
                    string companyId = Console.ReadLine();
                    Console.Write("Division      : ");
                    string divisionName = Console.ReadLine();

                    var division = new Division();
                    Guid guid = Guid.NewGuid();
                    division.DivisionId = resultDiv.DivisionId;
                    division.CompanyId = Guid.Parse(companyId);
                    division.DivisionName = divisionName;

                    _divAppService.Update(division);
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
