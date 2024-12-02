using EntLibraryProj.Entities;
using EntLibraryProj.Operations.Models;
using EntLibraryProj.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntLibraryProj.Operations.Controllers
{
    /// <summary>
    /// By Ryan. Primarily used for creating the table that shows off the users and their roles 
    /// </summary>
    [Route("[controller]")]
    public class UserController : Controller
    {
        private ILibraryService _libraryService;
        private ICategoryServices _categoryService;
        private IUserService _userService;
        List<SelectListItem> _selectListItemListOfCats;
        /// <summary>
        /// Constructor. Seems to be copied from the other control. Only really needs the User Service here, but adding the others doesn't seem to hurt. 
        /// </summary>
        /// <param name="libraryService"></param>
        /// <param name="categoryService"></param>
        /// <param name="userService"></param>
        public UserController(ILibraryService libraryService, ICategoryServices categoryService, IUserService userService)
        {
            _libraryService = libraryService;
            _categoryService = categoryService;
            _userService = userService;
            _selectListItemListOfCats = ModelActions.CreateSelectListItemListForCategories(_categoryService.ListCategory().ToList());
        }
        /// <summary>
        /// This displays a list of users, matching them to roles and displaying them in a table in the view of the same name. 
        /// </summary>
        /// <returns></returns>
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
