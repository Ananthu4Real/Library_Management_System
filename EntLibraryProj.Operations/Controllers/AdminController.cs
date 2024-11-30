using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EntLibraryProj.Services;
using EntLibraryProj.Entities;

namespace EntLibraryProj.Operations.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<LibraryUser> userManager;

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
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = createRoleViewModel.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(role);
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
        [Route("[action]")]
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }


        [Route("[action]")]
        [HttpGet]
        public IActionResult AddUserToRole()
        {
            return View();
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(AddUserRoleViewModel addUserRoleViewModel)
        {
            var role = await roleManager.FindByNameAsync(addUserRoleViewModel.RoleName);
            var user = await userManager.FindByEmailAsync(addUserRoleViewModel.UserName);

            if (user != null && role != null)
            {
                await userManager.AddToRoleAsync(user, role.Name);
                ViewBag.AddUserRoleMessage = "Success! User Added to Role.";

            }
            return View();
        }
    }
}
