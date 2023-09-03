using MediatR;
using Traversal_Web_App.CQRS.Results.GuideResults;

namespace Traversal_Web_App.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
