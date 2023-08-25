using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.MemberDashboard
{
    public class _ProfileInformationPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformationPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.memberName = values.Name + " " + values.Surname;
            ViewBag.memberPhone = values.PhoneNumber;
            ViewBag.memberMail = values.Email;
            return View();
        }
    }
}
