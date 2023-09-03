using BusinnessLayer.Abstract.AbstractUow;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;

namespace BusinnessLayer.Concrate.ConcreteUow
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public AccountManager(IUnitOfWorkDal unitOfWorkDal, IAccountDal accountDal)
        {
            _unitOfWorkDal = unitOfWorkDal;
            _accountDal = accountDal;
        }

        public Account TGetByID(int id)
        {
            return _accountDal.GetById(id);
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _unitOfWorkDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _unitOfWorkDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _unitOfWorkDal.Save();
        }
    }
}
