using DigitalDataStructure.Models;
using DigitalDataStructure.Security;
using DigitalDataStructure.SolidPrinciple;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace DigitalDataStructure.Controllers
{

    public class HomeController : Controller
    {
        //declaration
        private readonly IStudentService _service;
        private readonly IDataProtector _protector;
        private readonly CrudDigitalAppContext _appContext;

        public HomeController(IStudentService service,CrudDigitalAppContext context, DataSecurityProvider dataKey, IDataProtectionProvider provider)

        {
            _service = service;
            _protector = provider.CreateProtector(dataKey.dataKey);
            _appContext = context;
        }
        //function onward by repository
        /*public List<Student> GetUserList()
        {
            List<Student> s = new()
            {
                new Student { Id = 1, Name = "Dipesh", Address = "Nepal" },
                new Student { Id = 2, Name = "Smith", Address = "UK" },
                new Student { Id = 3, Name = "Ravi", Address = "India" }
            };
            return s;
        }*/
        public IActionResult Index()
        {
            //List<Student> s = new List<Student>();
            //var std = GetUserList();

            //to check the passed valued data correct or not
            // return Json(std);

          /*  var std = _service.GetStudents();
            var s = std.Select(e => new Student
            {
                Id = e.Id,
                Name = e.Name,
                Address = e.Address,
                encId = _protector.Protect(e.Id.ToString())
            }).ToList();

            return View(s);*/

            //operating with database
           var s = _service.GetStudents();
            var u = s.Select(e => new UserListEdit
            {
                UserId = e.UserId,
                UserName = e.UserName,
                EmailAddress = e.EmailAddress,
                UserAddress = e.UserAddress,
                UserPassword = e.UserPassword,
                UserProfile = e.UserProfile,
                EncId = _protector.Protect(e.UserId.ToString()),
                UserRole = e.UserRole
            }).ToList();
           return View(u);
            //return Json(s);
        }

        public IActionResult Details(string id)
        {
            var userid = Convert.ToInt32(_protector.Unprotect(id));

            UserList std = _service.GetStdById(userid);
            //return Json(std);
            return View(std);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserListEdit edit)
        {
            int maxid;
            if (_service.TetStudents().Any()) {
                maxid = _service.GetStudents().Max(x => x.UserId) + 1;
            }
            else
            {

            }
           
        }
    }
}
