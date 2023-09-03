using DataAccessLayer.Concrete;

namespace DataAccessLayer.UnitOfWork
{
    public class UowDal : IUnitOfWorkDal
    {
        private readonly Context _context;

        public UowDal(Context context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
