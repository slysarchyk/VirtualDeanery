﻿using System.Linq;
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

            var courslist = _db.StudentLists.
                Include(x => x.User).
                Include(x => x.Subject.Semester).
                Include(x => x.Subject.Semester.Faculty).
                Include(x => x.Subject.User).
                Where(x => x.UserId == userId).
                OrderByDescending(x => x.Subject.Semester.Id).
                AsNoTracking().
                ToList();

            IndexStudentViewModel isvw = new IndexStudentViewModel()
            {
                StudentLists = courslist
            };

            return View(isvw);
        }
    }
}