using BusinnessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.MemberDashboard
{
    public class _GuideListPartial : ViewComponent
    {
        private readonly GuideManager _guideManager = new GuideManager(new EFGuideDal());

        public IViewComponentResult Invoke()
        {
            var values = _guideManager.TGetList();
            return View(values);
        }
    }
}
