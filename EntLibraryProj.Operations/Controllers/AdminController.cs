using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EntLibraryProj.Services;
using EntLibraryProj.Entities;

namespace EntLibraryProj.Operations.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager; //This is used to manage and add roles
        private readonly UserManager<LibraryUser> userManager;  //Allows users to have roles assigned to them. LibraryUser is used over the base IdentityUSer

        //Constructor, adds roles
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<LibraryUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        
        [Route("[action]")]
        [HttpGet]
        //[Authorize]
        public IActionResult CreateRole()
        {

            return View();
        }
        //This uses the createRoleViewModel to create a new role in the base identity role table
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            //Checks to see if the model state is valid
            if (ModelState.IsValid)
            {
                //Using the received information from createRoleViewModel, it adds the role to the table.
                IdentityRole role = new IdentityRole
                {
                    Name = createRoleViewModel.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(role);
                //If successful, return to the list roles page. If failure, add a model error
                if (result.Succeeded)
                {
                    //return RedirectToAction("Index", "Home");
                    return RedirectToAction("ListRoles", "Admin");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(createRoleViewModel);
        }
        //Simply allows the ListRoles view to list off the roles
        [Route("[action]")]
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }


        //HTTPGet page for adding a user to a role
        [HttpGet]
        [Route("[action]")]
        public IActionResult AddUserToRole()
        {
            return View();
        }
        //Attempts to add the user to a role, using the addUserRoleViewModel object recieved from the page
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddUserToRole(AddUserRoleViewModel addUserRoleViewModel)
        {
            //If it can get the user name/password, it will attempt to add the user and matching role to the aspnet user role table
            var role = await roleManager.FindByNameAsync(addUserRoleViewModel.RoleName);
            var user = await userManager.FindByEmailAsync(addUserRoleViewModel.UserName);

            if (user != null && role != null)
            {
                await userManager.AddToRoleAsync(user, role.Name);
                ViewBag.AddUserRoleMessage = "Success! User Added to Role.";

            }
            //If it fails, display the proper message
            else
            {
                ViewBag.AddUserRoleMessage = "Problem: make sure you use email";
            }
            return View();
        }
    }
}
