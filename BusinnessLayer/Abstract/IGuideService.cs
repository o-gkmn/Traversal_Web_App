using EntityLayer.Concrete;

namespace BusinnessLayer.Abstract
{
    public interface IGuideService : IGenericService<Guide>
    {
        void TChangeToFalseByGuide(int id);
        void TChangeToTrueByGuide(int id);
    }
}
