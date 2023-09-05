using EntityLayer.Concrete;

namespace BusinnessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        public Destination TGetDestinationWithGuide(int id);

    }
}
