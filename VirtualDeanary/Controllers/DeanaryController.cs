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
        public IActionResult InfoStudentList(int? id)
        {
            var studentlist = _db.StudentLists.
                Include(x => x.User).
                Include(x => x.Course).
                Where(x => x.CourseId == id).
                OrderByDescending(x => x.Id).
                AsNoTracking().
                ToList();

            InfoStudentListViewModel islvw = new InfoStudentListViewModel()
            {
                StudentLists = studentlist
            };

            return View(islvw);
        }

        public IActionResult AddFaculty() => View();
        [HttpPost]
        public IActionResult AddFaculty(AddFacultyViewModel addfaculty)
        {
            if (ModelState.IsValid)
            {
                var facultyMap = _autoMapper.Map<AddFacultyViewModel, Faculty>(addfaculty);
                _db.Faculties.Add(facultyMap);
                _db.SaveChanges();
                return RedirectToAction("Index", "Deanary");
            }
            return View(addfaculty);
        }

        public IActionResult AddSemester() => View();
        [HttpPost]
        public IActionResult AddSemester(AddSemesterViewModel addSemester)
        {
            if (ModelState.IsValid)
            {
                var semesterMap = _autoMapper.Map<AddSemesterViewModel, Semester>(addSemester);
                _db.Semesters.Add(semesterMap);
                _db.SaveChanges();
                return RedirectToAction("Index", "Deanary");
            }
            return View(addSemester);
        }

        public IActionResult AddCourse() => View();
        [HttpPost]
        public IActionResult AddCourse(AddCourseViewModel addcourse)
        {
            if (ModelState.IsValid)
            {
                var courseMap = _autoMapper.Map<AddCourseViewModel, Course>(addcourse);
                _db.Courses.Add(courseMap);
                _db.SaveChanges();

                return RedirectToAction("Index", "Deanary");
            }
            return View(addcourse);
        }

        public IActionResult CreateStudentList() => View();
        [HttpPost]
        public IActionResult CreateStudentList(CreateStudentListViewModel creategroup)
        {
            if (ModelState.IsValid)
            {
                var mapUser = _autoMapper.Map<CreateStudentListViewModel, StudentList>(creategroup);
                _db.StudentLists.Add(mapUser);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(creategroup);
        }


        //переробити
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
                    Lastname = model.Lastname,
                    Teacher = model.Teacher
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