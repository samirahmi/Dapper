using Dapper;
using Day14_Dapper;
using Day14_Dapper.Applications;
using Day14_Dapper.Applications.Departments;
using Day14_Dapper.Applications.Divisions;
using Day14_Dapper.Applications.Employees;
using Day14_Dapper.Models;
using Day14_Dapper.Models.Views.Employees;
using Day14_Dapper.Views.Departments;
using Day14_Dapper.Views.Divisions;
using Day14_Dapper.Views.Employees;
using Npgsql;
using System.Diagnostics;


//// ======================================================================================================================
//// DAPEER dengan PERINTAH INSERT
//class Program
//{
//    private static string connectionString =
//        @"Host=localhost;Username=postgres;Password=sami;Database=ShippingDB;";
//    static void Main()
//    {
//        var student = new Student(); // Object bernama Student
//        student.StudentId = 1003; // Set StudentId
//        student.Name = "Hinata Shoyo"; // Set Name

//        using (var connection = new NpgsqlConnection(connectionString)) // menggunakan NpgsqlConnection punya ADO.Net
//        {
//            connection.Open();
//            connection.Execute("INSERT INTO Student (StudentId, Name) VALUES (@StudentId, @Name)",
//                new { StudentId = student.StudentId, Name = student.Name }); // Dapper melakukan eksekusi perintah INSERT
//            connection.Close();
//        }
//    }
//}

//public class Student // Blueprint dari Student
//{
//    public int StudentId { get; set; }
//    public string Name { get; set; }
//}

//// ======================================================================================================================
//// DAPEER dengan PERINTAH UPDATE
//class Program
//{
//    private static string connectionString =
//        @"Host=localhost;Username=postgres;Password=sami;Database=ShippingDB;";
//    static void Main()
//    {
//        var student = new Student(); // Object bernama Student
//        student.StudentId = 1003; // Set StudentId
//        student.Name = "Hinata Shoyo"; // Set Name

//        using (var connection = new NpgsqlConnection(connectionString)) // menggunakan NpgsqlConnection punya ADO.Net
//        {
//            connection.Open();
//            connection.Execute("UPDATE Student SET Name = @Name WHERE StudentId = @StudentId",
//                new { StudentId = student.StudentId, Name = student.Name }); // Dapper melakukan eksekusi perintah INSERT
//            connection.Close();
//        }
//    }
//}

//public class Student // Blueprint dari Student
//{
//    public int StudentId { get; set; }
//    public string Name { get; set; }
//}

// //======================================================================================================================
// //DAPEER dengan PERINTAH DELETE
//class Program
//{
//    private static string connectionString =
//        @"Host=localhost;Username=postgres;Password=sami;Database=ShippingDB;";
//    static void Main()
//    {
//        var student = new Student(); // Object bernama Student
//        student.StudentId = 1010; // Set StudentId

//        using (var connection = new NpgsqlConnection(connectionString)) // menggunakan NpgsqlConnection punya ADO.Net
//        {
//            connection.Open();
//            connection.Execute("DELETE FROM Student WHERE StudentId = @StudentId",
//                new { StudentId = student.StudentId }); // Dapper melakukan eksekusi perintah INSERT
//            connection.Close();
//        }
//    }
//}

//public class Student // Blueprint dari Student
//{
//    public int StudentId { get; set; }
//    public string Name { get; set; }
//}

////======================================================================================================================
////DAPEER dengan MENAMPILKAN List table semua STUDENT
//class Program
//{
//    private static string connectionString =
//        @"Host=localhost;Username=postgres;Password=sami;Database=ShippingDB;";
//    static void Main()
//    {
//        List<Student> students = new List<Student>(); // Object ListStudent
//        using (var connection = new NpgsqlConnection(connectionString)) // menggunakan NpgsqlConnection punya ADO.Net
//        {
//            connection.Open();
//            // cara1
//            students = connection.Query<Student>("SELECT * FROM Student").ToList();

//            // cara2
//            //var enumStudent = connection.Query<Student>("SELECT * FROM Student").AsEnumerable();
//            //students = enumStudent.ToList();

//            foreach (var student in students)
//            {
//                Console.WriteLine(student.StudentId + " - " + student.Name);
//            }
//            connection.Close();
//        }
//    }
//}

//public class Student // Blueprint dari Student
//{
//    public int StudentId { get; set; }
//    public string Name { get; set; }
//}

////======================================================================================================================
////DAPEER dengan MENAMPILKAN List table semua STUDENT
//class Program
//{
//    private static string connectionString =
//        @"Host=localhost;Username=postgres;Password=sami;Database=ShippingDB;";
//    static void Main()
//    {
//        Student student1 = new Student(); // membuat object baru
//        var studentID = 1001;

//        using (var connection = new NpgsqlConnection(connectionString)) // menggunakan NpgsqlConnection punya ADO.Net
//        {
//            connection.Open();
//            var students = connection.Query<Student>("SELECT * FROM Student WHERE StudentId = @StudentId",
//                new { StudentId = studentID }).ToList();
//            student1 = students.FirstOrDefault(); // untuk mengambil record pertama dari sebuah list
//            connection.Close();
//        }
//        Console.WriteLine(student1.StudentId + " - " + student1.Name);
//    }
//}

//public class Student // Blueprint dari Student
//{
//    public int StudentId { get; set; }
//    public string Name { get; set; }
//}



public class Program
{
    public static void Main(string[] args)
    {
        MenuView menu = new MenuView();
        menu.MainMenu();
    }
}