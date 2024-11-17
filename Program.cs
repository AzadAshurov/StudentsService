//CREATE DATABASE StudentService
//USE StudentService
//CREATE TABLE Students(
//Id INT PRIMARY KEY IDENTITY,
//[Name] VARCHAR(30),
//Iq INT NOT NULL
//)

namespace StudentsService
{
    internal class Program
    {
        private static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            Student student = new Student("Frog", 10);
            StudentService studentService = new StudentService();
            studentService.Add(student);
            for (int i = 0; i < 100; i++)
            {
                Student studentcloning = new Student($"Test{i}", 10 * i % 140 + 10);
                studentService.Add(studentcloning);
            }





            studentService.Delete(4);
            //Overload
            studentService.Delete(5, 100);
            //Can work like this
            studentService.Delete(150, 30);
            //Work even like this
            studentService.Delete(-23, 30);











            //Warning!!!!! Code in below comment is dangerous(Console beep warning and warning of epilepsy!!!)
            //studentService.Delete(-150, -30);







            Student student2 = new Student("Mahoraga", 150);
            studentService.Update(6, student2);

            students = studentService.GetAll();
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            Student studentFromSql = studentService.GetById(17);
            if (studentFromSql != null)
            {
                Console.WriteLine($"Name {studentFromSql.Name} and his Iq {studentFromSql.Iq}");
            }
            else
            {
                Console.WriteLine("No student with this id");
            }
        }


    }
}
