using DigitalDataStructure.Models;

namespace DigitalDataStructure.SolidPrinciple
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetList();

        Student GetStudentById(int id);

        void AddStudent(Student std);

        void UpdateStudent(Student std);

        void DeleteStudent(int id);
        
        
     }
 
}
