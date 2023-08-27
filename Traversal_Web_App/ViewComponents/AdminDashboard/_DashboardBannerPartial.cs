using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.AdminDashboard
{
    public class _DashboardBannerPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
