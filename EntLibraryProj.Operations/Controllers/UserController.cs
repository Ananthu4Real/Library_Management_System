using EntLibraryProj.Entities;
using EntLibraryProj.Operations.Models;
using EntLibraryProj.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntLibraryProj.Operations.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private ILibraryService _libraryService;
        private ICategoryServices _categoryService;
        private IUserService _userService;
        List<SelectListItem> _selectListItemListOfCats;

        public UserController(ILibraryService libraryService, ICategoryServices categoryService, IUserService userService)
        {
            _libraryService = libraryService;
            _categoryService = categoryService;
            _userService = userService;
            _selectListItemListOfCats = ModelActions.CreateSelectListItemListForCategories(_categoryService.ListCategory().ToList());
        }

        [Route("[action]")]
        public IActionResult ShowUsers()
        {
            List<LibraryUser> Items = _userService.GetUsers();
            List<string> roles = new List<string>();
            foreach (var item in Items)
            {
                roles.Add(_userService.GetRole(item.Id));
            }
            ShowUserView view = new ShowUserView() { LibraryUsers = Items, Roles = roles };
            return View(view);
        }

    }
}
