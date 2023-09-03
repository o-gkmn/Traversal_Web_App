using BusinnessLayer.Abstract.AbstractUow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal_Web_App.Areas.Admin.Models;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender = _accountService.TGetByID(model.SenderID);
            var valueReceiver = _accountService.TGetByID(model.ReceiverID);

            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;

            List<Account> modifiedAccounts = new()
            {
                valueSender,
                valueReceiver
            };

            _accountService.TMultiUpdate(modifiedAccounts);
            return View();
        }
    }
}
