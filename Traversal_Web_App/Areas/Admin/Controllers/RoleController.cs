using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal_Web_App.Areas.Admin.Models;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            var result = await _roleManager.CreateAsync(new AppRole
            {
                Name = model.Name,
            });

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {

            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new() 
            {
                Id = value.Id,
                Name = value.Name
            };
            return View(updateRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
            value.Name = model.Name;
            var result = await _roleManager.UpdateAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(value);
        }

        [HttpGet]
        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["Userid"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModel = new();
            foreach (var item in roles)
            {
                RoleAssignViewModel model = new();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.RoleExists = userRoles.Contains(item.Name);
                roleAssignViewModel.Add(model);
            }
            return View(roleAssignViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = (int) TempData["Userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in model)
            {
                if (item.RoleExists)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserList", "Role");
        }
    }
}
