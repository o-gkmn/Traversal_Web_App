using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        public List<Comment> GetListCommentsWithRelations();
        public List<Comment> GetListCommentsByDestinationID(int id);
    }
}
