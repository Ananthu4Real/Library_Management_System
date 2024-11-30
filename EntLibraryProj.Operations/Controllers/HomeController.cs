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

        public IActionResult Events()
        {
            var eventList = new List<EventModel>
            {
                new EventModel { Id = 1, Name = "Book Club Meeting", Date = new DateTime(2024, 12, 15, 18, 00, 00), Description = "Join us for an engaging discussion on our latest book selection.", ImageUrl = "/images/book-club.png" },
                new EventModel { Id = 2, Name = "Children's Storytime", Date = new DateTime(2024, 12, 20, 11, 00, 00), Description = "A fun-filled session of storytelling for kids aged 4-8.", ImageUrl = "/images/story-time.png" },
                new EventModel { Id = 3, Name = "Author Visit: Jane Doe", Date = new DateTime(2025, 1, 10, 16, 00, 00), Description = "Meet the renowned author and hear about her writing journey.", ImageUrl = "/images/author-visit.jpg" },
                new EventModel { Id = 4, Name = "Local History Seminar", Date = new DateTime(2025, 1, 25, 14, 30, 00), Description = "Discover the fascinating history of our community with a local historian.", ImageUrl = "/images/history-seminar.jpeg" },
                new EventModel { Id = 5, Name = "Poetry Reading Night", Date = new DateTime(2025, 2, 5, 18, 00, 00), Description = "Enjoy an evening of poetry readings from local and renowned poets.", ImageUrl = "/images/poetry-reading.jpg" },
                new EventModel { Id = 6, Name = "Digital Literacy Workshop", Date = new DateTime(2025, 2, 15, 10, 00, 00), Description = "Learn essential digital skills for everyday life in this hands-on workshop.", ImageUrl = "/images/digital-literacy.webp" },

            };

            return View(eventList);
        }
    }
}