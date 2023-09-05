using BusinnessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinnessLayer.Concrate
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            this._commentDal = commentDal;
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment? TGetById(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public List<Comment> TGetListCommentsByDestinationID(int id)
        {
            return _commentDal.GetListCommentsByDestinationID(id);
        }

        public List<Comment> TGetListCommentsWithRelations()
        {
            return _commentDal.GetListCommentsWithRelations();
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }

    }
}
