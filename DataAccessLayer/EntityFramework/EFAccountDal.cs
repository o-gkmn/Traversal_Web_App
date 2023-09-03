using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFAccountDal : GenericUowRepository<Account>, IAccountDal
    {
        public EFAccountDal(Context context) : base(context)
        {
        }
    }
}
