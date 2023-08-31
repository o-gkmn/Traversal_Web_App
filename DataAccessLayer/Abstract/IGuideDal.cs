using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IGuideDal : IGenericDal<Guide>
    {
        void ChangeToTrueByGuide(int id);
        void ChangeToFalseByGuide(int id);
    }
}
