using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinnessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> GetListApprovalReservation(int id);
    }
}
