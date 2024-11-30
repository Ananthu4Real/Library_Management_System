using EntLibraryProj.Models;
using EntLibraryProj.Operations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntLibraryProj.Operations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult FAQ()
    {
        var faqList = new List<FAQModel>
        {
            new FAQModel { Id = 1, Question = "What are the library hours?", Answer = "We are open from 9 AM to 8 PM on weekdays and 10 AM to 6 PM on weekends." },
            new FAQModel { Id = 2, Question = "Can I renew a book online?", Answer = "Yes, you can renew books through your account on our website." },
            new FAQModel { Id = 3, Question = "How many items can I borrow at once?", Answer = "You can borrow up to 10 items at a time." }
        };

        return View(faqList);
    }

    }
}
