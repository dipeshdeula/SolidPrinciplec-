using DigitalDataStructure.Models;

namespace DigitalDataStructure.SolidPrinciple
{
    public class StudentRepository : IStudentRepository
    {
        //raw input data
        /* List<Student> StudentList()
         {
             List<Student> s = new()
             {
                 new Student { Id = 1, Name="Dipesh", Address="Hetauda"},
                 new Student { Id = 2 , Name = "Sandesh", Address="Kathmandu"},
                 new Student { Id = 3 , Name = "Hari", Address="Pokhara"},
             };
             return s;
         }*/
        //data from database
        private readonly CrudDigitalAppContext _appContext;

        public StudentRepository(CrudDigitalAppContext appContext)
        { 
            _appContext = appContext;
        }

        public IEnumerable<UserList> GetList()
        {
           var u = _appContext.UserLists.ToList();
            return u;
        }

        public void AddStudent(UserList user)
        {
            _appContext.Add(user);
            _appContext.SaveChanges();
           
        }

        public UserList GetStudentById(int id)
        {
           var a = _appContext.UserLists.Where(x => x.UserId == id).First();
            return a;
        }

        public void UpdateStudent(UserList user)
        {
            _appContext.Update(user);
            _appContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
           /* var student = StudentList().Where(x => x.Id == id).First();
            StudentList().Remove(student);*/
        }
    }
}
