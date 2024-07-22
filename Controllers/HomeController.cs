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
        private IWebHostEnvironment _env;

        public HomeController(IStudentService service,CrudDigitalAppContext context,
            DataSecurityProvider dataKey, IDataProtectionProvider provider, IWebHostEnvironment env)

        {
            _service = service;
            _protector = provider.CreateProtector(dataKey.dataKey);
            _appContext = context;
            _env = env;
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
            if (_service.GetStudents().Any())
            {
                maxid = _service.GetStudents().Max(x => x.UserId) + 1;
            }
            else
            {
                maxid = 1;
            }
            edit.UserId = maxid;

            //upload file
            if(edit.UserFile != null)
            {
                string filename = maxid.ToString()+ Guid.NewGuid()+ Path.GetExtension(edit.UserFile.FileName);
                string filepath = Path.Combine(_env.WebRootPath, "UserProfile", filename);
                using (FileStream str = new FileStream(filepath, FileMode.Create)) 
                { 
                    edit.UserFile.CopyTo(str);
                
                }
                edit.UserProfile = filename;
            }
            //Mapping
            UserList u = new()
            {
                UserId = edit.UserId,
                EmailAddress = edit.EmailAddress,
                UserAddress = edit.UserAddress,
                UserName = edit.UserName,
                UserPassword = edit.UserPassword,
                UserProfile = edit.UserProfile,
                UserStatus = true

            };
            if (u != null)
            {
                _service.AddStd(u);
                return Json("success");

               // return View(edit); // Return the view after setting the UserId
            }
            else {
                return Json("failed");
                
            }
           

        }

    }
}
