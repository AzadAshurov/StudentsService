using System.Data;

namespace StudentsService
{
    internal class StudentService
    {
        private static Sql _sql;

        public StudentService()
        {
            _sql = new Sql();
        }

        public void Add(Student student)
        {
            _sql.Execute($"INSERT INTO Students VALUES ('{student.Name}', {student.Iq})");
        }

        public void Delete(int id)
        {
            _sql.Execute($"DELETE FROM Students WHERE {id} = Id");
        }
        public void Delete(int startId, int endId)
        {
            if (endId <= 0 && startId <= 0)
            {
                Console.WriteLine("Hah two negative id");
                System.Threading.Thread.Sleep(900);
                ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
                for (int i = 0; i <= 30; i++)
                {
                    Console.Beep();
                    Console.BackgroundColor = colors[new Random().Next(colors.Length)];
                    Console.ForegroundColor = colors[new Random().Next(colors.Length)];
                    Console.Clear();
                    System.Threading.Thread.Sleep(10);
                }
                Console.ResetColor();
                throw new Exception("You caused the collapse of the USSR, congratulations");
            }
            else if (endId < startId)
            {
                int passId = startId;
                startId = endId;
                endId = passId;
            }
            _sql.Execute($"DELETE FROM Students WHERE Id BETWEEN {startId} and {endId}");
        }
        public void Update(int id, Student student)
        {
            _sql.Execute($"UPDATE Students SET Name = '{student.Name}',Iq = '{student.Iq}' WHERE {id} = Id");
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            DataTable table = _sql.ExecuteQuery("SELECT * FROM Students");
            foreach (DataRow item in table.Rows)
            {
                Student student = new Student(
                item["Name"].ToString(),
                Convert.ToInt32(item["Iq"]));
                student.Id = Convert.ToInt32(item["Id"]);


                students.Add(student);
            }
            return students;
        }
        public Student GetById(int id)
        {
            DataTable table = _sql.ExecuteQuery($"SELECT * FROM Students WHERE Id = {id}");
            if (table.Rows.Count == 0)
            {
                return null;
            }
            var item = table.Rows[0];
            Student student = new Student(
            item["Name"].ToString(),
            Convert.ToInt32(item["Iq"]));
            student.Id = Convert.ToInt32(item["Id"]);
            return student;
        }
    }
}
