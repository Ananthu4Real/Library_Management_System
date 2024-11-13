using EntLibraryProj.Entities;
using EntLibraryProj.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntLibraryProj.Operations.Controllers
{
    public class LibraryController : Controller
    {
        private IBookService _bookService;
        private IMovieService _movieService;
        private ILibraryService _libraryService;

        public LibraryController(IBookService bookService, IMovieService movieService, ILibraryService libraryService)
        {
            _bookService = bookService;
            _movieService = movieService;
            _libraryService = libraryService;
        }
        public IActionResult ShowItems() 
        { 
            List<LibraryItem> Items = _libraryService.GetItems().ToList();
            return View(Items);
        }
    }
}
