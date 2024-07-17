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

        public HomeController(IStudentService service, DataSecurityProvider dataKey, IDataProtectionProvider provider)

        {
            _service = service;
            _protector = provider.CreateProtector(dataKey.dataKey);
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

            var std = _service.GetStudents();
            var s = std.Select(e => new Student
            {
                Id = e.Id,
                Name = e.Name,
                Address = e.Address,
                encId = _protector.Protect(e.Id.ToString())
            }).ToList();

            return View(s);
        }

        public IActionResult Details(string id)
        {
            var userid = Convert.ToInt32(_protector.Unprotect(id));

            Student std = _service.GetStdById(userid);
            //return Json(std);
            return View(std);
        }
    }
}
