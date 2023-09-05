using EntityLayer.Concrete;

namespace BusinnessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> TGetListCommentsWithRelations();
        List<Comment> TGetListCommentsByDestinationID(int id);
    }
}
