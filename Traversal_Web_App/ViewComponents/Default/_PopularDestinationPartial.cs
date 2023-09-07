using BusinnessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.Default
{
    public class _PopularDestinationPartial : ViewComponent
    {
        private readonly IDestinationService _destinationManager;

        public _PopularDestinationPartial(IDestinationService destinationManager)
        {
            _destinationManager = destinationManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }
    }
}
