using DataAccessLayer.Concrete;
using Traversal_Web_App.CQRS.Commands.DestinationCommands;

namespace Traversal_Web_App.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationID);
            values.City = command.City;
            values.DayNight = command.DayNight;
            values.Price = command.Price;
            _context.Update(values);
            _context.SaveChanges();
        }
    }
}
