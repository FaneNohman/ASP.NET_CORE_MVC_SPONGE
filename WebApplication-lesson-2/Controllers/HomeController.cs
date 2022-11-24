using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebApplication_lesson_2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_lesson_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _dbContext;
        public HomeController(ILogger<HomeController> logger, DBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Friends(string quearyString)
        {

            var friends = from f in _dbContext.Friends
                          select f;
            if (!String.IsNullOrEmpty(quearyString))
            {
                friends = from f in friends where f.FirstName.Contains(quearyString) select f;
            }

            return View(friends);
        }
        public async Task<IActionResult> Homes()
        {

            var homes = from h in _dbContext.Homes
                          select h;

            return View(await _dbContext.Homes.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}