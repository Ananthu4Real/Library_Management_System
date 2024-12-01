using EntLibraryProj.Entities;
using EntLibraryProj.Operations.Models;
using EntLibraryProj.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace EntLibraryProj.Operations.Controllers
{
    [Route("[controller]")]
    public class LibraryController : Controller
    {
        private ILibraryService _libraryService;
        private ICategoryServices _categoryService;
        private IUserService _userService;
        List<SelectListItem> _selectListItemListOfCats;

        public LibraryController(ILibraryService libraryService, ICategoryServices categoryService, IUserService userService)
        {
            _libraryService = libraryService;
            _categoryService = categoryService;
            _userService = userService;
            _selectListItemListOfCats = ModelActions.CreateSelectListItemListForCategories(_categoryService.ListCategory().ToList());
        }
        [Route("[action]")]
        public IActionResult ShowItems() 
        {
            List<LibraryItem> Items = _libraryService.GetItems();
            return View(Items);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult AddItem()
        {
            ViewBag.CategoryId = _selectListItemListOfCats;
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddItem(LibraryItem item)
        {
            ViewBag.CategoryId = _selectListItemListOfCats;
            if(item != null)
            {
                if(item.CategoryId >0 && item.CategoryId < 11)
                {
                    item.CategoryId -= 1;
                    item.Category = _categoryService.ListCategory().ElementAt(item.CategoryId);
                }
            }

            if (_libraryService.GetItem(item.LibItemId) != null)
            {
                ViewBag.Status = true;
                return View();
            }
            
            item.Available = item.Inventory; //available = inventory
            //item.DateAdded = DateOnly.FromDateTime(DateTime.Now); //today
            _libraryService.AddItem(item);
            return RedirectToAction("ShowItems");
        }
        [Authorize(Roles = "Admin")]
        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult DeleteItem(int id) 
        {
            LibraryItem? item = _libraryService.GetItem(id); //grab item
            foreach(LibraryUser user in _userService.GetUsers())
            {
                _userService.RemoveLibItem(user.UserName, id);
            }
            if (item == null) { return RedirectToAction("ShowItems"); }
            _libraryService.DeleteItem(id);
            return RedirectToAction("ShowItems");
        }

        [Authorize]
        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult ItemDetails(int? id)
        {
            int i = id ?? 1;

            LibraryItem? item = _libraryService.GetItem(i);
            if (item == null) {return RedirectToAction("ShowItems"); }
            return View(item);
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult UpdateItem(int id)
        {
            LibraryItem? item = _libraryService.GetItem(id);
            if (item == null) { return RedirectToAction("ShowItems"); }
            
            ViewBag.CategoryId = _selectListItemListOfCats;
            return View(item);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult UpdateItem(LibraryItem item)
        {
            ViewBag.CategoryId = _selectListItemListOfCats;
            if (item != null)
            {
                if (item.CategoryId > 0 && item.CategoryId < 11)
                {
                    item.CategoryId -= 1;
                    item.Category = _categoryService.ListCategory().ElementAt(item.CategoryId);
                }
            }
            _libraryService.UpdateItem(item);
            return RedirectToAction("ShowItems");
        }
        [Route("[action]/{CategoryType?}")]
        [Route("/ItemsByCat/{id?}")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult ListItemsByCategory(string? CategoryType, int? id)
        {
            //If id is not set, let it be 1
            int i = id ?? 1;
            //Get All cats as a list
            List<Category> categories = _categoryService.ListCategory().ToList();

            //Gets a list of cats to a SelectItemList type, as shown in class.
            List<SelectListItem> listOfCategories = _selectListItemListOfCats;

            //used for the different methods of routing
            foreach (Category cat in categories)
            {
                if (CategoryType == cat.CategoryId.ToString())
                {
                    CategoryType = cat.CategoryName;
                    i = cat.CategoryId;
                }
            }

            //Add the list of cats (SelectListItem type) as a property of ViewBag, and the selected id below, for use on the view for filtering by department
            ViewBag.CategoryType = listOfCategories;

            ViewBag.SelectedCategory = i.ToString();
            return View(_libraryService.GetItems());
        }

        [Route("[action]")]
        public IActionResult ItemByCreationDateSearch(string? ChosenDate)
        {
            ViewBag.ChosenDate = ChosenDate;

            try
            {
                DateTime dateConvert = DateTime.Parse(ChosenDate, CultureInfo.InvariantCulture);
                String.Format("{0:yyyy-MM-dd}", dateConvert);

                List<LibraryItem> allItems = _libraryService.GetItems();
                List<LibraryItem> dateListOfItems = new List<LibraryItem>();
                foreach (var item in allItems)
                {
                    if (item.DateCreated != null)
                    {
                        DateTime dateConvert2 = DateTime.Parse(item.DateCreated, CultureInfo.InvariantCulture);
                        String.Format("{0:yyyy-MM-dd}", dateConvert2);
                        if (dateConvert2 > dateConvert)
                        {
                            dateListOfItems.Add(item);
                        }
                    }

                }
                return View(dateListOfItems);
            }
            catch
            {
                return View(_libraryService.GetItems());
            }
        }
        [Authorize]
        [Route("[action]/{id}")]
        public IActionResult CheckOutBook(int id)
        {
            string name = User.Identity.Name;
            bool stat = _libraryService.CheckOutBook(id);
            if (stat)
            {
                stat = _userService.AddLibItem(name, id);
                if (!stat)
                {
                    _libraryService.ReturnBook(id);
                }
            }
            return RedirectToAction(nameof(ShowItems));
        }

        [Authorize]
        [Route("[action]/{id}")]
        public IActionResult Return(int id)
        {
            string name = User.Identity.Name;
            bool stat = _libraryService.ReturnBook(id);
            if (stat)
            {
                stat = _userService.RemoveLibItem(name, id);
                if (!stat)
                {
                    _libraryService.CheckOutBook(id);
                }
            }
            return RedirectToAction(nameof(ShowItems));
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public IActionResult CheckedOut() //show all items a user has checked out
        {
            string name = User.Identity.Name; //get logged in user
            LibraryUser user = _userService.GetLibraryUser(name); //get name associated with u-name
            List<int> items = new List<int>();
            if (user.itemId1 != null) { items.Add((int)user.itemId1); }
            if (user.itemId2 != null) { items.Add((int)user.itemId2); }
            if (user.itemId3 != null) { items.Add((int)user.itemId3); }
            if (items.Count == 0) { return RedirectToAction("Index", "Home"); }// no checked out item
            List<LibraryItem> list = new List<LibraryItem>();
            foreach (var item in items)
            {
                LibraryItem? libraryItem = _libraryService.GetItem(item);
                if (libraryItem != null)
                {
                    list.Add(libraryItem);
                }
            }
            return View(list);
        }
    }
}
