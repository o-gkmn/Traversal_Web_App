using BusinnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentManager;
        private readonly IAppUserService _appUserManager;

        public CommentController(IAppUserService appUserManager, ICommentService commentManager)
        {
            _appUserManager = appUserManager;
            _commentManager = commentManager;
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.destID = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.AppUserID = _appUserManager.FindByUserName(User.Identity.Name).Id;
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            _commentManager.TAdd(p);
            return RedirectToAction("DestinationDetails", "Destination", new { id = p.DestinationID});
        }
    }
}
