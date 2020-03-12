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

            var semester = _db.Semesters.
                Include(x => x.Faculty).
                Where(x => x.FacultyId == id).
                OrderByDescending(x => x.Id).
                AsNoTracking().
                ToList();

            InfoFacultyViewModel ifvw = new InfoFacultyViewModel()
            {
                Semesters = semester
            };

            return View(ifvw);
        }
        public IActionResult InfoSemester(int? id)
        {
            if (id == null)
                return NotFound();

            var course = _db.Courses.
                Include(x => x.Semester).
                Include(x => x.User).
                Where(x => x.SemesterId == id).
                OrderByDescending(x => x.Id).
                AsNoTracking().
                ToList();

            InfoSemesterViewModel isvw = new InfoSemesterViewModel()
            {
                Courses = course
            };

            return View(isvw);
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

        public IActionResult CreateMark() => View();

        [HttpPost]
        public IActionResult CreateMark(CreateMarkViewModel group)
        {
            if (ModelState.IsValid)
            {
                var mapUser = _autoMapper.Map<CreateMarkViewModel, Mark>(group);
                _db.Marks.Add(mapUser);
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