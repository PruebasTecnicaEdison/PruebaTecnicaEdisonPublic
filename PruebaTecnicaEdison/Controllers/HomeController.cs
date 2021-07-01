using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnicaEdison.Business.BL;
using PruebaTecnicaEdison.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PruebaTecnicaEdison.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonBL _personBL;

        public HomeController(ILogger<HomeController> logger, IPersonBL personBL)
        {
            _logger = logger;
            _personBL = personBL;
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

        public async Task<IActionResult> AddPerson(Person model)
        {
            if (ModelState.IsValid)
            {
                await _personBL.AddPerson(model);
                return Redirect("Filter");
            }
            ModelState.Clear();
            return View();
        }

        public async Task<IActionResult> Filter(int documentNumber)
        {
            var model = await _personBL.GetPeople(documentNumber);
            return View(model);
        }
    }
}
