using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using VirtualDeanary.Data;
using VirtualDeanary.Models;
using VirtualDeanery.Data.Models;
using VirtualDeanary.Data.Models;

namespace VirtualDeanary.Controllers
{
    public class DeanaryController : Controller
    {
        private readonly IMapper _autoMapper;
        private readonly SqlContext _db;
        private readonly UserManager<User> _um;

        public DeanaryController(
            IMapper mapper,
            SqlContext context,
            UserManager<User> userManager)
        {
            _autoMapper = mapper;
            _db = context;
            _um = userManager;
        }

        public IActionResult Index()
        {
            IndexDeanaryViewModel idvw = new IndexDeanaryViewModel()
            {
                Faculties = _db.Faculties.AsNoTracking().ToList()
            };

            return View(idvw);
        }

        public IActionResult InfoFaculty(int? id)
        {
            if (id == null)
                return NotFound();

            var group = _db.Groups.
                Where(x => x.FacultyId == id).
                Include(x => x.Faculty).
                Include(x => x.Course).
                Include(x => x.User).
                AsNoTracking().ToList();

            InfoFacultyViewModel info = new InfoFacultyViewModel()
            {
                Groups = group
            };

            return View(info);
        }

        public IActionResult AddCourse() => View();

        [HttpPost]
        public IActionResult AddCourse(AddCourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                var courseMap = _autoMapper.Map<AddCourseViewModel, Course>(course);
                _db.Courses.Add(courseMap);
                _db.SaveChanges();

                return RedirectToAction("Index", "Deanary");
            }
            return View(course);
        }

        public IActionResult AddUserToGroup() => View();

        [HttpPost]
        public IActionResult AddUserToGroup(AddUserToGroupViewModel group)
        {
            if (ModelState.IsValid)
            {
                var mapUser = _autoMapper.Map<AddUserToGroupViewModel, Groups>(group);
                _db.Groups.Add(mapUser);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(group);
        }


        [HttpGet]
        public IActionResult AddUser() => View();

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Year = model.Year,
                    Name = model.Name,
                    Lastname = model.Lastname
                };
                var result = await _um.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}