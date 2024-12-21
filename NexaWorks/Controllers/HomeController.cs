using Microsoft.AspNetCore.Mvc;
using NexaWorks.Models;
using NexaWorks.Repository;
using System.Diagnostics;

namespace NexaWorks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRequetes _requetes;

        public HomeController(ILogger<HomeController> logger, IRequetes requetes)
        {
            _logger = logger;
            _requetes = requetes;
        }

        #region requetes
        public async Task<IActionResult> AllTicketsNotResolved()
        {
            var tickets = await _requetes.GetAllTicketsNotResolved();
            return View(tickets);
        }
        public async Task<IActionResult> AllTicketsNotResolvedFromProduct(int prodId)
        {
            var tickets = await _requetes.GetAllTicketsNotResolvedOfThisProductID(prodId);
            return View(tickets);
        }
        public async Task<IActionResult> AllTicketsNotResolvedFromVersion(int verId)
        {
            var tickets = await _requetes.GetAllTicketsNotResolvedOfThisVersionID(verId);
            return View(tickets);
        }
        #endregion



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
