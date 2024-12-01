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
        //Allows accessing the various services to perform CRUD ops on related database tables
        private ILibraryService _libraryService;
        private ICategoryServices _categoryService;
        private IUserService _userService;
        List<SelectListItem> _selectListItemListOfCats; //Used for category drop down lists
       
        //Initiates the controller and the services used
        public LibraryController(ILibraryService libraryService, ICategoryServices categoryService, IUserService userService)
        {
            _libraryService = libraryService;
            _categoryService = categoryService;
            _userService = userService;
            //Calls function to get the categories as a list of select list item objects
            _selectListItemListOfCats = ModelActions.CreateSelectListItemListForCategories(_categoryService.ListCategory().ToList());
        }
        [Route("[action]")]
        public IActionResult ShowItems() 
        {
            List<LibraryItem> Items = _libraryService.GetItems();
            return View(Items);
        }
        /// <summary>
        /// Create operation input field section. Sends input to see if it can create the item. Validation is included
        /// </summary>
        /// <returns></returns>
        //Requires admin role to add items
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult AddItem()
        {
            //checks if valid model
            if (!ModelState.IsValid)
            {
                return View();
            }
            //Add the list of categories (SelectListItem type) as a property of ViewBag in the view
            ViewBag.CategoryId = _selectListItemListOfCats;
            return View();
        }
        /// <summary>
        /// Create Operation for library items
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]    //Reqs admin role to add users
        [Route("[action]")]
        [HttpPost]
        public IActionResult AddItem(LibraryItem item)
        {
            //Need to set the viewbag again to show the dropdown list and allow the validation to go through. 
            ViewBag.CategoryId = _selectListItemListOfCats;
            if(item != null)
            {
                //Need to subtract the category id by one due to how the setup was implemented
                if (item.CategoryId >0 && item.CategoryId < 11)
                {
                    item.CategoryId -= 1;
                    //needs to set the category to pass validation
                    item.Category = _categoryService.ListCategory().ElementAt(item.CategoryId);
                }
            }
            //If the id isn't already used, allow the item to be made
            if (_libraryService.GetItem(item.LibItemId) != null)
            {
                ViewBag.Status = true;
                return View();
            }
            
            //Implements availability feature to make sure that the item can actually be taken out. Automatically set up to = the initial inventory input
            item.Available = item.Inventory; //available = inventory
            //check if valid model
            if (!ModelState.IsValid)
            {
                return View();
            }
            //item.DateAdded = DateOnly.FromDateTime(DateTime.Now); //today. Instead, added a way to add it during initial input
            _libraryService.AddItem(item);
            return RedirectToAction("ShowItems");
        }

        //Admin required to delete items. 
        /// <summary>
        /// Delete operation. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult DeleteItem(int id) 
        {
            LibraryItem? item = _libraryService.GetItem(id); //grab item
            foreach(LibraryUser user in _userService.GetUsers())       //Removes the items from users if they have them checked out
            {
                _userService.RemoveLibItem(user.UserName, id);
            }
            //If the item doesn't exist, go back to the items list. 
            if (item == null) { return RedirectToAction("ShowItems"); }
            //Otherwise delete the item and redirect to items list
            _libraryService.DeleteItem(id);
            return RedirectToAction("ShowItems");
        }
        /// <summary>
        /// Item details, usually selected by the itemslist view. Checks id to see if it matches an existing item to perform read op
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Decided to not need higher authoritization to read item details
        [Authorize]
        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult ItemDetails(int? id)
        {
            //If the id is null, set i to 1, checking the first item
            int i = id ?? 1;

            LibraryItem? item = _libraryService.GetItem(i);
            //If the item is null, go back to items list
            if (item == null) {return RedirectToAction("ShowItems"); }
            //If it isn't view the item
            return View(item);
        }
        //Requires the admin role to update items.
        /// <summary>
        /// Gets the input to update items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult UpdateItem(int id)
        {
            //This viewbag allows the category drop down list to work
            ViewBag.CategoryId = _selectListItemListOfCats;
            //Get the item. If it doesn't exist, go to item list again
            LibraryItem? item = _libraryService.GetItem(id);
            if (item == null) { return RedirectToAction("ShowItems"); }
            //Checks the model state. If it is not good, return. If good, proceed
            if (!ModelState.IsValid)
            {
                return View();
            }

            return View(item);
        }
        /// <summary>
        /// Updates items from the given input. Performs validation and refactors cat id to be correct
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]    //reqs admin role to update
        [Route("[action]")]
        [HttpPost]
        public IActionResult UpdateItem(LibraryItem item)
        {
            //Need to set the viewbag again to show the dropdown list and allow the validation to go through. 
            ViewBag.CategoryId = _selectListItemListOfCats;
            if (item != null)
            {
                //Makes sure there is not more than the total inventory available.
                if(item.Available > item.Inventory) item.Available = item.Inventory;

                //Need to subtract the category id by one due to how the setup/workaround functions. 
                if (item.CategoryId > 0 && item.CategoryId < 11)
                {
                    item.CategoryId -= 1;
                    //needs to set the category to pass validation
                    item.Category = _categoryService.ListCategory().ElementAt(item.CategoryId);
                }
                
            }
            //check if valid model. If good, the item is updated
            if (!ModelState.IsValid)
            {
                
                return View();
            }

            //Edits the library item
            _libraryService.UpdateItem(item);
            return RedirectToAction("ShowItems", "Library");
        }
        /// <summary>
        /// Lists items by category. Requires the viewbag of categories to get the dropdown list input to work. 
        /// Uses the input to search for a valid category to decern items by
        /// </summary>
        /// <param name="CategoryType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
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

            //Add the list of cats (SelectListItem type) as a property of ViewBag, and the selected id below, for use on the view for filtering by category
            ViewBag.CategoryType = listOfCategories;

            ViewBag.SelectedCategory = i.ToString();
            return View(_libraryService.GetItems());
        }

        /// <summary>
        /// Searches the library items by their date of creation. For example, inputting 01-01-2000 will only show
        /// items the were published after the year 2000 began
        /// </summary>
        /// <param name="ChosenDate"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Checks out a book for an existing user. Reduces the number of books by 1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Return the book from the user's posession. This will increase the number of available items by one.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// User can only have a max of 3 items checked out
        /// </summary>
        /// <returns></returns>
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
