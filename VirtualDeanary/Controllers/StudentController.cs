using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualDeanary.Data;
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
        public IActionResult Index()
        {
            var userId = _um.GetUserId(User);
            var courselist = _db.StudentLists.
                Include(x => x.Course.Semester.Faculty).
                Include(x => x.User).
                Include(x => x.Course.User).
                OrderByDescending(x => x.Id).
                AsNoTracking().
                Where(x => x.UserId == userId).
                ToList();

            IndexStudentViewModel isvw = new IndexStudentViewModel()
            {
                StudentLists = courselist
            };

            return View(isvw);
        }
    }
}