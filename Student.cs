namespace StudentsService
{
    public class Student
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Iq { get; set; }

        public Student(string name, int iq)
        {

            Name = name;
            Iq = iq;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, IQ: {Iq}";
        }
    }
}
