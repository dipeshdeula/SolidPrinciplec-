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

        public IEnumerable<UserList> GetStudents() => _repo.GetList();


        public UserList GetStdById(int id)
        { 
            return _repo.GetStudentById(id);
        }
       
        public void AddStd(UserList std)
        {
            
        }

        public void UpdateStd(UserList std)
        {
            
        }

        public void DeleteStd(int id)
        {
            
        }
    }
}
