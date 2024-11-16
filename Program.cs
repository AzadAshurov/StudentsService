//CREATE DATABASE StudentService
//USE StudentService
//CREATE TABLE Students(
//Id INT PRIMARY KEY IDENTITY,
//[Name] VARCHAR(30),
//Iq INT NOT NULL
//)

using System.Data.SqlClient;

namespace StudentsService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = $"server=DESKTOP-JR023V5\\SQLEXPRESS;database=StudentService;trusted_connection=true;integrated security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "INSERT INTO Students ([Name], Iq) VALUES ('Tom', 150), ('Frog', 10)";
                SqlCommand command = new SqlCommand(query, connection);
                int result = command.ExecuteNonQuery();
                Console.WriteLine(result);
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Razval sssr");
            }

        }
    }
}
