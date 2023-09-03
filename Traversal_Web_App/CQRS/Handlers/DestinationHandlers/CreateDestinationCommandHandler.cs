using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Traversal_Web_App.CQRS.Commands.DestinationCommands;

namespace Traversal_Web_App.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new Destination
            {
                City = command.City,
                Price = command.Price,
                DayNight = command.DayNight,
                Capacity = command.Capacity,
                Status = true
            });

            _context.SaveChanges();
        }
    }
}
