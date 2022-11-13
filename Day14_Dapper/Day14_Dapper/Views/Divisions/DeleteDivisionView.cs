using Day14_Dapper.Applications.Divisions;
using Day14_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Divisions
{
    public class DeleteDivisionView
    {
        private readonly IDivisionAppService _divAppService;

        public DeleteDivisionView(IDivisionAppService divAppService)
        {
            _divAppService = divAppService;
        }

        public void DisplayView()
        {
            Console.Clear();
            Console.WriteLine("Delete Division");
            Console.WriteLine("----------------");

            Console.Write("Type Division Id : ");
            var divisionId = Console.ReadLine();
            var resultDiv = _divAppService.GetModelById(Guid.Parse(divisionId));

            if (resultDiv != null)
            {
                Console.WriteLine($"Company       : {resultDiv.CompanyId}");
                Console.WriteLine($"Division Name : {resultDiv.DivisionName}");

                Console.Write("Are you sure want to DELETE this record? (Y/N)");
                var choise = Console.ReadLine();

                if (choise.ToUpper().Equals("Y"))
                {
                    var division = new Division();
                    division.DivisionId = resultDiv.DivisionId;
                    division.CompanyId = resultDiv.CompanyId;
                    division.DivisionName = resultDiv.DivisionName;

                    _divAppService.Delete(Guid.Parse(divisionId));
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
