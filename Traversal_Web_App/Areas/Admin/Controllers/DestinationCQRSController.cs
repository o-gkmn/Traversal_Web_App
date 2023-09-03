using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal_Web_App.CQRS.Commands.DestinationCommands;
using Traversal_Web_App.CQRS.Handlers.DestinationHandlers;
using Traversal_Web_App.CQRS.Queries.DestinationQueries;
using Traversal_Web_App.CQRS.Results.DestinationResults;

namespace Traversal_Web_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationCQRSController : Controller
    {
        private readonly IMapper _mapper;
        private readonly GetAllDestinationQueryHandler _handler;
        private readonly GetDestinationByIDQueryHandler _getDestinationByIDQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler handler, GetDestinationByIDQueryHandler getDestinationByIDQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler, IMapper mapper)
        {
            _handler = handler;
            _getDestinationByIDQueryHandler = getDestinationByIDQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _handler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIDQueryHandler.Handle(new GetDestinationByIDQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult GetDestination(GetDestinationByIDQueryResult command)
        {
            var mappedCommand = _mapper.Map<UpdateDestinationCommand>(command);
            _updateDestinationCommandHandler.Handle(mappedCommand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }
    }
}
