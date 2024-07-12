using DigitalDataStructure.Models;

namespace DigitalDataStructure.SolidPrinciple
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Student> GetStudents() => _repo.GetList();


        public Student GetStdById(int id)
        { 
            return _repo.GetStudentById(id);
        }
       
        public void AddStd(Student std)
        {
            
        }

        public void UpdateStd(Student std)
        {
            
        }

        public void DeleteStd(int id)
        {
            
        }
    }
}
