using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IContactUsDal : IGenericDal<ContactUs>
    {
        List<ContactUs> GetListContactUsByTrue();
        List<ContactUs> GetListContactUsByFalse();
        void ContactUsStatusChangeToFalse(int id);
    }
}
