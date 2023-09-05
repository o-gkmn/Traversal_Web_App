using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentsWithRelations()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Destination).Include(x => x.AppUser).ToList();
            }
        }

        public List<Comment> GetListCommentsByDestinationID(int id)
        {
            using (var c = new Context())
            {
                return c.Comments.Where(x => x.DestinationID == id).Include(x => x.AppUser).ToList();
            }
        }
    }
}
