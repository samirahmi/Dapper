using Day14_Dapper.Applications.Employees;
using Day14_Dapper.Models.Views.Employees;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Employees
{
    public class EmployeeView
    {
        public void DisplayView()
        {         
            IEmployeeAppService empAppService = new EmployeeAppService();

            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose an Option");
                Console.WriteLine("1) Create Employee");
                Console.WriteLine("2) Update Employee");
                Console.WriteLine("3) Delete Employee");
                Console.WriteLine("4) Get All Employee");
                Console.WriteLine("5) Exit");
                Console.Write("\r\n Select an Option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        //View
                        var createEmpView = new CreateEmployeeView(empAppService);
                        createEmpView.DisplayView();
                        showMenu = true;
                        break;
                    case "2":
                        //View
                        var updateEmpView = new UpdateEmployeeView(empAppService);
                        updateEmpView.DisplayView();
                        showMenu = true;
                        break;
                    case "3":
                        //View
                        var deleteEmpView = new DeleteEmployeeView(empAppService);
                        deleteEmpView.DisplayView();
                        showMenu = true;
                        break;
                    case "4":
                        //View
                        var getAllEmpView = new GetAllEmployeeView(empAppService);
                        getAllEmpView.DisplayView();
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
