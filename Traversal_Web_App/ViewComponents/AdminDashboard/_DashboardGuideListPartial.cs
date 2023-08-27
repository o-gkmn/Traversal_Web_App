using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.AdminDashboard
{
    public class _DashboardGuideListPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
