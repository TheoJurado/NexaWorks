using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private List<string> SplitKeyWord(string keyWord)
        {
            if (string.IsNullOrWhiteSpace(keyWord))
                return new List<string>();//if keyWord is empty

            //all Spliter
            char[] separateurs = new char[] { ' ', '\t', '\n', '\r', ',', ';', '.', '!', '?', ':' };
            string[] mots = keyWord.Split(separateurs, StringSplitOptions.RemoveEmptyEntries);

            return new List<string>(mots);
        }


        #region requetes not resolved
        public async Task<IActionResult> AllTicketsNotResolved()
        {
            var tickets = await _requetes.GetAllTicketsNotResolved();
            return View("Index",tickets);
        }
        public async Task<IActionResult> AllTicketsNotResolvedFromProduct(int prodId)
        {
            var tickets = await _requetes.GetAllTicketsNotResolvedOfThisProductID(prodId);
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsNotResolvedFromVersion(int verId)
        {
            var tickets = await _requetes.GetAllTicketsNotResolvedOfThisVersionID(verId);
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsFromProductAndTime(int prodId, DateOnly dateStart, DateOnly dateEnd)
        {
            var tickets = await _requetes.GetAllTicketsOfThisProductIDInThisTimeLap(prodId, dateStart, dateEnd);
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsFromVersionAndTime(int verId, DateOnly dateStart, DateOnly dateEnd)
        {
            var tickets = await _requetes.GetAllTicketsOfThisVersionIDInThisTimeLap(verId, dateStart, dateEnd);
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsNotResolvedWithKeyWord(string keyWord)
        {
            var tickets = await _requetes.GetAllTicketsNotResolvedWithTheseWords(SplitKeyWord(keyWord));
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsNotResolvedFromProductWithKeyWord(int prodId, string keyWord)
        {
            var tickets = await _requetes.GetAllTicketsNotResolvedOfThisProductIDWithTheseWords(prodId, SplitKeyWord(keyWord));
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsNotResolvedFromVersionWithKeyWord(int verId, string keyWord)
        {
            var tickets = await _requetes.GetAllTicketsNotResolvedOfThisVersionIDWithTheseWords(verId, SplitKeyWord(keyWord));
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsFromProductionWithKeyWordAndTime(int prodId, string keyWord, DateOnly dateStart, DateOnly dateEnd)
        {
            var tickets = await _requetes.GetAllTicketsOfThisProductIDWithTheseWordsInThisTimeLap(prodId, SplitKeyWord(keyWord), dateStart, dateEnd);
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsFromVersionnWithKeyWordAndTime(int verId, string keyWord, DateOnly dateStart, DateOnly dateEnd)
        {
            var tickets = await _requetes.GetAllTicketsOfThisVersionIDWithTheseWordsInThisTimeLap(verId, SplitKeyWord(keyWord), dateStart, dateEnd);
            return View("Index", tickets);
        }
        #endregion

        #region requetes solved
        public async Task<IActionResult> AllTicketsSolved()
        {
            var tickets = await _requetes.GetAllTicketsSolved();
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsSolvedFromProduct(int prodId)
        {
            var tickets = await _requetes.GetAllTicketsSolvedOfThisProductID(prodId);
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsSolvedFromVersion(int verId)
        {
            var tickets = await _requetes.GetAllTicketsSolvedOfThisVersionID(verId);
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsFromProductSolvedInTime(int prodId, DateOnly dateStart, DateOnly dateEnd)
        {
            var tickets = await _requetes.GetAllTicketsOfThisProductIDSolvedInThisTimeLap(prodId, dateStart, dateEnd);
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsFromVersionSolvedInTime(int verId, DateOnly dateStart, DateOnly dateEnd)
        {
            var tickets = await _requetes.GetAllTicketsOfThisVersionIDSolvedInThisTimeLap(verId, dateStart, dateEnd);
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsSolvedWithKeyWord(string keyWord)
        {
            var tickets = await _requetes.GetAllTicketsSolvedWithTheseWords(SplitKeyWord(keyWord));
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsSolvedFromProductWithKeyWord(int prodId, string keyWord)
        {
            var tickets = await _requetes.GetAllTicketsSolvedOfThisProductIDWithTheseWords(prodId, SplitKeyWord(keyWord));
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsSolvedFromVersionWithKeyWord(int verId, string keyWord)
        {
            var tickets = await _requetes.GetAllTicketsSolvedOfThisVersionIDWithTheseWords(verId, SplitKeyWord(keyWord));
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsFromProductionWithKeyWordSolvedInTime(int prodId, string keyWord, DateOnly dateStart, DateOnly dateEnd)
        {
            var tickets = await _requetes.GetAllTicketsOfThisProductIDWithTheseWordsSolvedInThisTimeLap(prodId, SplitKeyWord(keyWord), dateStart, dateEnd);
            return View("Index", tickets);
        }
        public async Task<IActionResult> AllTicketsFromVersionnWithKeyWordSolvedInTime(int verId, string keyWord, DateOnly dateStart, DateOnly dateEnd)
        {
            var tickets = await _requetes.GetAllTicketsOfThisVersionIDWithTheseWordsSolvedInThisTimeLap(verId, SplitKeyWord(keyWord), dateStart, dateEnd);
            return View("Index", tickets);
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
