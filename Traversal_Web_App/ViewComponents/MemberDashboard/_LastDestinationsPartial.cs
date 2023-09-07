using BusinnessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.MemberDashboard
{
    public class _LastDestinationsPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _LastDestinationsPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetLastFourDestinations();
            return View(values);
        }
    }
}
