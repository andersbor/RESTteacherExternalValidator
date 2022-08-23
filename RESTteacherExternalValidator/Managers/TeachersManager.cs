using RESTteacherExternalValidator.Models;

namespace RESTteacherExternalValidator.Managers
{
    public class TeachersManager
    {
        private static int _nextId = 1;
        private static readonly List<Teacher> Data = new List<Teacher> {
           new Teacher {Id = _nextId++, Name = "Anders", Salary = 100 },
           new Teacher { Id = _nextId++, Name = "Peter", Salary= 110},
           new Teacher {Id = _nextId, Name = "Henrik", Salary = 120}
        };

        public List<Teacher> GetAll()
        {
            return new List<Teacher>(Data);
        }

        public Teacher? GetById(int id) { return Data.FirstOrDefault(t => t.Id == id); }

        public Teacher Add(Teacher teacher)
        {
            TeacherValidator.Validate(teacher); // may throw exception
            teacher.Id = _nextId++;
            Data.Add(teacher);
            return teacher;
        }

        public Teacher? Delete(int id)
        {
            Teacher? t = Data.FirstOrDefault(t => t.Id == id);
            if (t == null) return null; // or exception ??
            Data.Remove(t);
            return t;
        }
    }
}
