using AutoMapper;
using BusinnessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendMessageDto model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _contactUsService.TAdd(new ContactUs()
            {
                MessageBody = model.MessageBody,
                Mail = model.Mail,
                MessageDate = DateTime.Now,
                MessageStatus = true,
                Name = model.Name,
                Subject = model.Subject,
            });
            return RedirectToAction("Index", "Default");
        }
    }
}
