using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VirtualDeanary.Data;
using VirtualDeanary.Models;
using VirtualDeanery.Data.Models;

namespace VirtualDeanary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _autoMapper;
        private readonly SqlContext _db;

        public HomeController(ILogger<HomeController> logger, 
            IMapper mapper,
            SqlContext context)
        {
            _logger = logger;
            _autoMapper = mapper;
            _db = context;
        }

        public IActionResult Index() 
        {
            return View();
        } 

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
