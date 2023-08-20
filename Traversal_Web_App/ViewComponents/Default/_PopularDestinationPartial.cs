using BusinnessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.Default
{
    public class _PopularDestinationPartial : ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());

        public IViewComponentResult Invoke()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
    }
}
