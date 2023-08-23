using BusinnessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Areas.Member.Controllers
{
    [AllowAnonymous]
    [Area("Member")]
    public class DestinationController : Controller
    {
        private readonly DestinationManager _destinationManager = new DestinationManager(new EFDestinationDal());

        public IActionResult Index()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }
    }
}
