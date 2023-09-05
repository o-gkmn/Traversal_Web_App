using BusinnessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentManager;

        public CommentController(ICommentService commentManager)
        {
            _commentManager = commentManager;
        }

        public IActionResult Index()
        {
            var values = _commentManager.TGetListCommentsWithRelations();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var values = _commentManager.TGetById(id);
            _commentManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
