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

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
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
    }
}
