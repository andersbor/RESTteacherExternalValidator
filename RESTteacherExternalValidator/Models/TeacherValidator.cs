namespace RESTteacherExternalValidator.Models
{
    public static class TeacherValidator
    {
        public static void ValidateSalary(Teacher teacher)
        {
            if (teacher.Salary < 0)
                throw new ArgumentOutOfRangeException("Salary must be at least 0: " + teacher.Salary);
        }

        public static void ValidateName(Teacher teacher)
        {
            if (teacher.Name == null)
                throw new ArgumentNullException("name is null");
            if (teacher.Name.Length < 1)
                throw new ArgumentException("name must be at least 1 character");
        }

        public static void Validate(Teacher teacher)
        {
            ValidateSalary(teacher);
            ValidateName(teacher);
        }
    }
}
