namespace RESTteacherExternalValidator.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Salary { get; set; }

        override
        public string ToString()
        { return Id + " " + Name + " " + Salary; }
    }
}
