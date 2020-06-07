using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T.STORE.SYSTEM.Application.Users;
using T.STORE.SYSTEM.WebPage.Models;

namespace T.STORE.SYSTEM.WebPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserAppService _userAppService;
        public HomeController(
            IUserAppService userAppService
            )
        {
            _userAppService = userAppService;
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
