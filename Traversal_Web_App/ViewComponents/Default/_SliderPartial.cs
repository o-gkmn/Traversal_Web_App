using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
