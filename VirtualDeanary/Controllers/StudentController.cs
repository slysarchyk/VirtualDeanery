using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualDeanary.Data;
using VirtualDeanary.Data.Models;
using VirtualDeanary.Models;
using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly IMapper _autoMapper;
        private readonly SqlContext _db;
        private readonly UserManager<User> _um;

        public StudentController(
            IMapper mapper,
            SqlContext context,
            UserManager<User> userManager)
        {
            _autoMapper = mapper;
            _db = context;
            _um = userManager;
        }
        public IActionResult Index(int studyYear)
        {
            var userId = _um.GetUserId(User);

            IQueryable<StudentList> quareble = _db.StudentLists.
                Include(x => x.Course.Semester.Faculty).
                Include(x => x.User).
                Include(x => x.Course.User);

            if (studyYear > 0 && studyYear < 4)
            {
                quareble = quareble.Where(y => y.Course.Semester.StudyYear == studyYear);
            }

            IndexStudentViewModel isvw = new IndexStudentViewModel()
            {
                StudentLists = quareble.OrderByDescending(x => x.Id).Where(x => x.UserId == userId).ToList(),
                StudyYear = studyYear
            };

            return View(isvw);
        }
    }
}