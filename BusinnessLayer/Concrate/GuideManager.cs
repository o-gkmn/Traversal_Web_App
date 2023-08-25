using BusinnessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinnessLayer.Concrate
{
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void TAdd(Guide t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Guide t)
        {
            throw new NotImplementedException();
        }

        public Guide? TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Guide> TGetList()
        {
            return _guideDal.GetList();
        }

        public void TUpdate(Guide t)
        {
            throw new NotImplementedException();
        }
    }
}
