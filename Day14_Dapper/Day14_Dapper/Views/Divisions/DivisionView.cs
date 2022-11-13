using Day14_Dapper.Applications.Divisions;
using Day14_Dapper.Applications.Employees;
using Day14_Dapper.Models.Views.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Divisions
{
    public class DivisionView
    {
        public void DisplayView()
        {
            IDivisionAppService divAppService = new DivisionAppService();

            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose an Option");
                Console.WriteLine("1) Create Division");
                Console.WriteLine("2) Update Division");
                Console.WriteLine("3) Delete Division");
                Console.WriteLine("4) Get All Division");
                Console.WriteLine("5) Exit");
                Console.Write("\r\n Select an Option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        var createDivView = new CreateDivisionView(divAppService);
                        createDivView.DisplayView();
                        showMenu = true;
                        break;
                    case "2":
                        var updateDivView = new UpdateDivisionView(divAppService);
                        updateDivView.DisplayView();
                        showMenu = true;
                        break;
                    case "3":
                        var deleteDivView = new DeleteDivisionView(divAppService);
                        deleteDivView.DisplayView();
                        showMenu = true;
                        break;
                    case "4":
                        var getAllDivView = new GetAllDivisionView(divAppService);
                        getAllDivView.DisplayView();
                        showMenu = true;
                        break;
                    case "5":
                        showMenu = false;
                        break;
                    default:
                        MenuView menu = new MenuView();
                        menu.MainMenu();
                        showMenu = true;
                        break;
                }
            }
        }
    }
}
