using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.MemberLayout
{
    public class _MemberLayoutHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
