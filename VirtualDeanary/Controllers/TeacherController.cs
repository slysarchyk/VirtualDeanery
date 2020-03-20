using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualDeanary.Data;
using VirtualDeanary.Models;
using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IMapper _autoMapper;
        private readonly SqlContext _db;
        private readonly UserManager<User> _um;

        public TeacherController(
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
            var userId = _um.GetUserId(User);

            var courseList = _db.Subjects.
                Include(x => x.User).
                Include(x => x.Semester.Faculty).
                Where(x => x.UserId == userId).
                AsNoTracking().
                ToList();

            IndexTeacherViewModel itvw = new IndexTeacherViewModel()
            {
                Courses = courseList
            };

            return View(itvw);
        }
    }
}