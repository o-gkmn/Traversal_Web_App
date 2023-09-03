using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Traversal_Web_App.CQRS.Results.DestinationResults;

namespace Traversal_Web_App.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                DestinationID = x.DestinationID,
                City = x.City,
                Capacity = x.Capacity,
                DayNight = x.DayNight,
                Price = x.Price
            }).AsNoTracking().ToList();

            return values;
        }
    }
}
