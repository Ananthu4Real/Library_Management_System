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
        public void CheckItems(LibraryItem item)
        {
            if (item.Type == "Book")
            {
                item.Check = _bookService.GetBook(item.CheckId);
                return;
            }
            if (item.Type == "Movie")
            {
                item.Check = _movieService.GetMovie(item.CheckId);
                return;
            }
        }
        public IActionResult ShowItems() 
        {
            List<LibraryItem> Items = _libraryService.GetItems();
            /*
            foreach(LibraryItem item in Items)
            {
               CheckItems(item);
            }
            */
            return View(Items);
        }

    }
}
