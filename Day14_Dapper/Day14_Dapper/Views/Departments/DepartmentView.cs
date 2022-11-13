using Day14_Dapper.Applications.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Dapper.Views.Departments
{
    public class DepartmentView
    {
        public void DisplayView()
        {
            IDepartmentAppService deptAppService = new DepartmentAppService();

            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose an Option");
                Console.WriteLine("1) Create Department");
                Console.WriteLine("2) Update Department");
                Console.WriteLine("3) Delete Department");
                Console.WriteLine("4) Get All Department");
                Console.WriteLine("5) Exit");
                Console.Write("\r\n Select an Option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        var createDeptView = new CreateDepartmentView(deptAppService);
                        createDeptView.DisplayView();
                        showMenu = true;
                        break;
                    case "2":
                        var updateDeptView = new UpdateDepartmentView(deptAppService);
                        updateDeptView.DisplayView();
                        showMenu = true;
                        break;
                    case "3":
                        var deleteDeptView = new DeleteDepartmentView(deptAppService);
                        deleteDeptView.DisplayView();
                        showMenu = true;
                        break;
                    case "4":
                        var getAllDeptView = new GetAllDepartmentView(deptAppService);
                        getAllDeptView.DisplayView();
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
