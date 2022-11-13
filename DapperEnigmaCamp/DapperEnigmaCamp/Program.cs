////// ADO .NET ini digunakan untuk mengakses RDBMS seperti SQL Server, MySQL, Postgre dll. Dibawah .Net 4.3
////// Kebanyakan di pakai di aplikasi Desktop. Umumnya di Visual Studio 2013, 2010, 2009, 2008, 2005 kebawah.
////// Dapper = Object Mapping untuk mengakses RDBMS seperti SQL Server, MySQL, Postgre dll. 
////// Dapper menggunakan engine punya ADO .Net. Cuma beda nya di Dapper kita kirim dan terima berupa object.

////using Dapper;
////using System.Data.SqlClient;

////class Program
////{
////    private static string connectionString =
////                    @"Server=DESKTOP-QEO3NAA\SQLEXPRESS;Database=ShippingDB;Trusted_Connection=True;";
////    static void Main()
////    {
////        var student = new Student(); // Object bernama Student
////        student.StudentId = 1010; // Set StudentId
////        student.Name = "Naruto"; // Set Name

////        using (var connection = new SqlConnection(connectionString)) // menggunakan SQLConnection punya ADO .Net
////        {
////            connection.Open(); // Open koneksi 
////            connection.Execute("INSERT INTO Students (StudentId, Name) VALUES (@StudentId, @Name)",
////                new { StudentId = student.StudentId, Name = student.Name }); // Dapper melakukan eksekusi perintah INSERT
////            connection.Close(); // Koneksi ditutup
////        }
////    }
////}

////public class Student // Blueprint dari Student
////{
////    public int StudentId { get; set; }
////    public string Name { get; set; }
////}

////using Dapper;
////using System.Data.SqlClient;

////class Program
////{
////    private static string connectionString =
////                    @"Server=DESKTOP-QEO3NAA\SQLEXPRESS;Database=ShippingDB;Trusted_Connection=True;";
////    static void Main()
////    {
////        var student = new Student(); // Object bernama Student
////        student.StudentId = 1002; // Set StudentId
////        student.Name = "Andika Kangen Band"; // Set Name

////        using (var connection = new SqlConnection(connectionString)) // menggunakan SQLConnection punya ADO .Net
////        {
////            connection.Open(); // Open koneksi 
////            connection.Execute("UPDATE Students SET Name = @Name WHERE StudentId = @StudentId",
////                new { StudentId = student.StudentId, Name = student.Name }); // Dapper melakukan eksekusi perintah INSERT
////            connection.Close(); // Koneksi ditutup
////        }
////    }
////}

////public class Student // Blueprint dari Student
////{
////    public int StudentId { get; set; }
////    public string Name { get; set; }
////}


//using Dapper;
//using System.Data.SqlClient;

//class Program
//{
//    private static string connectionString =
//                    @"Server=DESKTOP-QEO3NAA\SQLEXPRESS;Database=ShippingDB;Trusted_Connection=True;";
//    static void Main()
//    {
//        //List<Student> students = new List<Student>();
//        //using (var connection = new SqlConnection(connectionString)) // menggunakan SQLConnection punya ADO .Net
//        //{
//        //    connection.Open(); // Open koneksi 
//        //    students = connection.Query<Student>("SELECT * FROM Students").ToList();
//        //    //students = enumStudent.ToList();

//        //    foreach (var student in students)
//        //    {
//        //        Console.WriteLine(student.StudentId + " - " + student.Name);
//        //    }

//        //    connection.Close(); // Koneksi ditutup
//        //}

//        Student student = new Student();
//        var Id = 1002;
//        using (var connection = new SqlConnection(connectionString))
//        {
//            connection.Open();
//            var studentRepo = connection.Query<Student>(
//                "SELECT * FROM Students WHERE StudentId = @StudentId", 
//                new { StudentId = Id }).ToList();
//            student = studentRepo.FirstOrDefault();
//            connection.Close();
//        }

//        Console.WriteLine(student.StudentId + " - " + student.Name);
//    }
//}

//public class Student // Blueprint dari Student
//{
//    public int StudentId { get; set; }
//    public string Name { get; set; }
//}

using Dapper;
using DapperEnigmaCamp.Applications.Dto;
using DapperEnigmaCamp.Applications.Employees;
using DapperEnigmaCamp.Views.Employees;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        #region Scalar
        //string connString =
        //    @"Server=DESKTOP-QEO3NAA\SQLEXPRESS;Database=ShippingDB;Trusted_Connection=True;";
        //// Execute Scalar
        //using (var connection = new SqlConnection(connString))
        //{
        //    connection.Open();
        //    var countEmployee = connection.ExecuteScalar("SELECT COUNT(*) FROM Employee");
        //    Console.WriteLine($"Total Employee {countEmployee}");
        //    connection.Close();
        //}

        //return;
        #endregion
               
        //var empService = new EmployeeAppService() Global, semua interface bisa di pake
        #region MainMenu
        bool showMenu = true;
        while (showMenu)
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Company");
            Console.WriteLine("2) Division");
            Console.WriteLine("3) Department");
            Console.WriteLine("4) Employee");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    // View
                    //var createEmpView = new CreateEmployeeView(empAppService);
                    //createEmpView.DisplayView();
                    showMenu = true;
                    break;
                case "2":
                    // View
                    //var updateEmpView = new UpdateEmployeeView(empAppService);
                    //updateEmpView.DisplayView();
                    showMenu = true;
                    break;
                case "3":
                    // View
                    showMenu = true;
                    break;
                case "4":
                    // View
                    //var getAllEmpView = new GetAllEmployeeView(empAppService);
                    //getAllEmpView.DisplayView();
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
        #endregion
    }
}