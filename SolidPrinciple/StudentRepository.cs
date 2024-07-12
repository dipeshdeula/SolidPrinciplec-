using DigitalDataStructure.Models;

namespace DigitalDataStructure.SolidPrinciple
{
    public class StudentRepository : IStudentRepository
    {
        List<Student> StudentList()
        {
            List<Student> s = new()
            {
                new Student { Id = 1, Name="Dipesh", Address="Hetauda"},
                new Student { Id = 2 , Name = "Sandesh", Address="Kathmandu"},
                new Student { Id = 3 , Name = "Hari", Address="Pokhara"},
            };
            return s;
        }

        public IEnumerable<Student> GetList()
        {
            return StudentList();
        }

        public void AddStudent(Student std)
        {
            StudentList().Add(std);
        }

        public Student GetStudentById(int id)
        {
            return StudentList().Where(x => x.Id == id).First();
        }

        public void UpdateStudent(Student std)
        {
            var student = StudentList().Where(x => x.Id == std.Id).First();
            student.Name = std.Name;
            student.Address = std.Address;
        }

        public void DeleteStudent(int id)
        {
            var student = StudentList().Where(x => x.Id == id).First();
            StudentList().Remove(student);
        }
    }
}
