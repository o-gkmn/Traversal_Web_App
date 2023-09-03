namespace Traversal_Web_App.CQRS.Queries.DestinationQueries
{
    public class GetDestinationByIDQuery
    {
        public GetDestinationByIDQuery(int id)
        {
            DestinationID = id;
        }

        public int DestinationID { get; set; }
    }
}
