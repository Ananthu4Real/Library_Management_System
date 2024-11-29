using EntLibraryProj.Entities;
using EntLibraryProj.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntLibraryProj.Operations.Controllers
{
    public class LibraryController : Controller
    {
        private ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        public IActionResult ShowItems() 
        {
            List<LibraryItem> Items = _libraryService.GetItems();
            return View(Items);
        }

        [HttpGet]
        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(LibraryItem item)
        {
            if (_libraryService.GetItem(item.ItemId) != null)
            {
                ViewBag.Status = true;
                return View();
            }
            //item.Available = item.Inventory; //available = inventory
            //item.DateAdded = DateOnly.FromDateTime(DateTime.Now); //today
            _libraryService.AddItem(item);
            return RedirectToAction("ShowItems");
        }

        [HttpGet]
        public IActionResult DeleteItem(int id) 
        {
            _libraryService.DeleteItem(id);
            return RedirectToAction("ShowItems");
        }

        [HttpGet]
        public IActionResult ItemDetails(int id)
        {
            LibraryItem? item = _libraryService.GetItem(id);
            if (item == null) {return RedirectToAction("ShowItems"); }
            return View(item);
        }
        [HttpGet]
        public IActionResult UpdateItem(int id)
        {
            LibraryItem? item = _libraryService.GetItem(id);
            if (item == null) { return RedirectToAction("ShowItems"); }
            return View(item);
        }
        [HttpPost]
        public IActionResult UpdateItem(LibraryItem item)
        {
            _libraryService.UpdateItem(item);
            return RedirectToAction("ShowItems");
        }

    }
}
