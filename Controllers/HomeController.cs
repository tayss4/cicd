using Fiap.Web.Trafego.Data.Contexts;
using Fiap.Web.Trafego.Logging;
using Fiap.Web.Trafego.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiap.Web.Trafego.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomLogger _customLogger;   
        private readonly DatabaseContext _context;

        public HomeController(ICustomLogger customLogger, DatabaseContext context)
        {
            _customLogger = customLogger;
            _context = context;
        }

        public IActionResult Index()
        {
            var lista = _context.Cruzamentos.ToList();
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
