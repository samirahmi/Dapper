using Day14_Dapper.Applications.Departments;
using Day14_Dapper.Applications.Divisions;
using Day14_Dapper.Applications.Employees;
using Day14_Dapper.Views.Departments;
using Day14_Dapper.Views.Divisions;
using Day14_Dapper.Views.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper
{
    public class MenuView
    {
        public void MainMenu()
        {
            //string connString =
            //    @"Host=localhost;Username=postgres;Password=sami;Database=Gudang;";
            //using(var connection = new NpgsqlConnection(connString))
            //{
            //    connection.Open();
            //    var countEmployee = connection.ExecuteScalar($"SELECT COUNT(*) FROM Employee");
            //    Console.WriteLine($"Total Employee {countEmployee}");
            //    connection.Close();
            //}

            //return;


            //IEmployeeAppService empAppService = new EmployeeAppService();
            //IDivisionAppService divAppService = new DivisionAppService();
            //IDepartmentAppService deptAppService = new DepartmentAppService();

            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose an Option");
                Console.WriteLine("1) Company");
                Console.WriteLine("2) Division");
                Console.WriteLine("3) Department");
                Console.WriteLine("4) Employee");
                Console.WriteLine("5) Exit");
                Console.Write("\r\n Select an Option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        //View
                        showMenu = true;
                        break;
                    case "2":
                        var divView = new DivisionView();
                        divView.DisplayView();
                        showMenu = true;
                        break;
                    case "3":
                        var deptView = new DepartmentView();
                        deptView.DisplayView();
                        showMenu = true;
                        break;
                    case "4":
                        //View
                        var empView = new EmployeeView();
                        empView.DisplayView();
                        showMenu = true;
                        break;
                    case "5":
                        showMenu = false;
                        break;
                    default:
                        showMenu = true;
                        break;
                }
            }
        }
    }
}
