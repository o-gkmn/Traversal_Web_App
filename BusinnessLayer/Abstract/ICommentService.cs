using EntityLayer.Concrete;

namespace BusinnessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> TGetDestinationByID(int id);
        List<Comment> TGetListCommentsWithDestination();
    }
}
