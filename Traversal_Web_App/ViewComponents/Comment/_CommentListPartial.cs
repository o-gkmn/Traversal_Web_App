using BusinnessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Web_App.ViewComponents.Comment
{
    public class _CommentListPartial : ViewComponent
    {
        private readonly CommentManager _commentManager = new CommentManager(new EFCommentDal());

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentManager.TGetListCommentsByDestinationID(id);
            return View(values);
        }
    }
}
