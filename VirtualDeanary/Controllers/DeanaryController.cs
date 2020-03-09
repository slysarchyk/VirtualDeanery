using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VirtualDeanary.Data;
using Microsoft.EntityFrameworkCore;
using VirtualDeanary.Models;
using VirtualDeanary.Data.Models;

namespace VirtualDeanary.Controllers
{
    public class DeanaryController : Controller
    {
        private readonly IMapper _autoMapper;
        private readonly SqlContext _db;

        public DeanaryController(
            IMapper mapper,
            SqlContext context)
        {
            _autoMapper = mapper;
            _db = context;
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
    }
}