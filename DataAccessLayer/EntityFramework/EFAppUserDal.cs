using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
    }
}
