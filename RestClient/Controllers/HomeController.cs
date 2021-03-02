using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RestClient.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestClient.Controllers
{
    public class HomeController : Controller
    {
        #region logger

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region get

        public IActionResult Startseite()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        #endregion

        #region error

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
