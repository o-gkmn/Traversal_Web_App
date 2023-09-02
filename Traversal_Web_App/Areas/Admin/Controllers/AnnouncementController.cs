using AutoMapper;
using BusinnessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.TGetList());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDto model)
        {
            if (ModelState.IsValid)
            {
                var value = _mapper.Map<Announcement>(model);
                value.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                _announcementService.TAdd(value);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementService.TGetById(id);
            _announcementService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var value = _mapper.Map<AnnouncementUpdateDto>(_announcementService.TGetById(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var value = _mapper.Map<Announcement>(model);
                value.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                _announcementService.TUpdate(value);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
