using MediatR;
using Traversal_Web_App.CQRS.Results.GuideResults;

namespace Traversal_Web_App.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
