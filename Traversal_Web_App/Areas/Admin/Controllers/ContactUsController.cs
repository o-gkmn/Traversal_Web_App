using BusinnessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values = _contactUsService.TGetListContactUsByTrue();
            return View(values);
        }
    }
}
