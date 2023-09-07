using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.MemberLayout
{
    public class _MemberLayoutHeaderContentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
