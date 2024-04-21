using Microsoft.AspNetCore.Mvc;
using MyFirstMVCCoreWebApp.Models;
using System.Diagnostics;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace MyFirstMVCCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AtcgsaWithoutAspnetauthContext _dbconn; // Object >> 
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, AtcgsaWithoutAspnetauthContext dbconn, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _dbconn = dbconn;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            // INSERT UPDATE DELETE
            var getData = _dbconn.TblUsers.ToList();

            var envName = _hostingEnvironment.EnvironmentName;
            var ApplicationName = _hostingEnvironment.ApplicationName;
            var WebRootPath = _hostingEnvironment.WebRootPath;
            var ContentRootFileProvider = _hostingEnvironment.ContentRootFileProvider;

            return View();
        }


        public IActionResult Index1()
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